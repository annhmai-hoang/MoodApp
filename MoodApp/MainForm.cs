using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace MoodApp
{
    public partial class MainForm : Form
    {
        private readonly string dbPath = "Data Source=moods.db;Version=3;";

        private Random random;

        private readonly HashSet<string> positiveMoods = new HashSet<string>
        {
        "Happy", "Grateful", "Relaxed", "Excited", "Confident",
        "Inspired", "Loved", "Hopeful", "Content", "Proud"
        };

        private readonly HashSet<string> neutralMoods = new HashSet<string>
        {
            "Calm", "Thoughtful", "Focused", "Tired",
            "Indifferent", "Nostalgic"
        };

        private readonly HashSet<string> negativeMoods = new HashSet<string>
        {
            "Stressed", "Anxious", "Overwhelmed", "Lonely", "Sad",
            "Frustrated", "Angry", "Unmotivated", "Disappointed", "Drained"
        };

        private int currentPage = 1;
        private int pageSize = 10;  // Number of records per page
        private int totalRecords;


        public MainForm()
        {
            InitializeComponent();
            LoadMoodLog(1);
            GetRandomAffirmation();
            UpdateMoodChart();
            random = new Random();
        }


        // Log mood and update past mood log, saving the mood to the log
        private void LogMoodbutton_Click(object sender, EventArgs e)
        {
            if (MoodcomboBox.SelectedItem != null)
            {
                string mood = MoodcomboBox.SelectedItem.ToString();
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");


                // When inserting a mood, make sure it's linked to the logged-in user
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Moods (Date, Mood, UserID) VALUES (@Date, @Mood, @UserID)";
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Mood", mood);
                        command.Parameters.AddWithValue("@UserID", Login.LoggedInUserID);
                        command.ExecuteNonQuery();
                    }
                }

                // Refresh mood log and update mood chart after saving
                LoadMoodLog(1);
                UpdateMoodChart();
            }
        }


        // Load user-specific past mood log
        private void LoadMoodLog(int page)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                // Get total record count
                string countQuery = "SELECT COUNT(*) FROM Moods WHERE UserID=@userID";
                using (var countCommand = new SQLiteCommand(countQuery, connection))
                {
                    countCommand.Parameters.AddWithValue("@userID", Login.LoggedInUserID);
                    totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
                }

                // Calculate offset
                int offset = (page - 1) * pageSize;

                // Fetch paginated records
                string query = @"
                    SELECT Date, Mood 
                    FROM Moods 
                    WHERE UserID=@userID
                    ORDER BY Date DESC 
                    LIMIT @PageSize OFFSET @Offset";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);

                    command.Parameters.AddWithValue("@userID", Login.LoggedInUserID);

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        moodDataGridView.DataSource = dt;
                    }
                }
            }

            // Hide the blank column (row headers)
            moodDataGridView.RowHeadersVisible = false;


            UpdatePaginationButtons();
        }


        // Update Page number and count
        private void UpdatePaginationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            lblPageNumber.Text = $"Page {currentPage} of {totalPages}";

            btnPrevPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
        }


        // Prev page button click
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadMoodLog(currentPage);
            }
        }


        // Next page button click
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadMoodLog(currentPage);
            }
        }


        // Generate random affirmation from db
        private void GetRandomAffirmation()
        {
            string affirmation = "You are awesome!"; // Default message if DB is empty

            using (var connection = new SQLiteConnection(dbPath)) 
            {
                connection.Open();
                string query = "SELECT Message FROM Affirmations ORDER BY RANDOM() LIMIT 1";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        affirmation = reader.GetString(0);
                    }
                }
            }
            NewAffbutton.Text = affirmation;
        }

        // Call Get method for affirmation
        private void NewAffbutton_Click(object sender, EventArgs e)
        {
            GetRandomAffirmation();
        }


        // Get the moods for the user's in past 7 days, tally them into 3 categories
        private Dictionary<string, int> GetWeeklyMoodData()
        {
            Dictionary<string, int> moodCounts = new Dictionary<string, int>
            {
                {"Positive", 0},
                {"Neutral", 0},
                {"Negative", 0}
            };

            string query = @"
                SELECT Mood, COUNT(*) as Count 
                FROM Moods
                WHERE UserID=@userID
                AND Date >= date('now', '-7 days')
                GROUP BY Mood";

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", Login.LoggedInUserID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string mood = reader["Mood"].ToString();
                            int count = Convert.ToInt32(reader["Count"]);

                            if (positiveMoods.Contains(mood)) moodCounts["Positive"] += count;
                            else if (neutralMoods.Contains(mood)) moodCounts["Neutral"] += count;
                            else if (negativeMoods.Contains(mood)) moodCounts["Negative"] += count;
                        }
                    }
                }
            }

            return moodCounts;
        }


        // Update the chart whenever a new mood is logged
        private void UpdateMoodChart()
        {
            var moodData = GetWeeklyMoodData();

            moodChart.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };

            foreach (var category in moodData)
            {
                series.Points.AddXY(category.Key, category.Value);
            }

            moodChart.Series.Add(series);
        }

        
        // Log out button
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        // Make sure when we close MainForm, everything is closed
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Ensures all threads and forms are closed properly
        }

        // Redirect to Journal
        private void btnJournal_Click(object sender, EventArgs e)
        {
            JournalForm journalForm = new JournalForm();
            journalForm.Show();
        }

        // Surprise!
        private void btnCheerUp_Click(object sender, EventArgs e)
        {
            string[] videos = {
                "https://www.youtube.com/watch?v=dQw4w9WgXcQ", // Rickroll
                "https://www.youtube.com/watch?v=kJQP7kiw5Fk", // Despacito
                "https://www.youtube.com/watch?v=7ZhdXgRfxHI&pp=ygUNYW5pbWFsIHBsYW5ldA%3D%3D", // Nature with Sir David Attenborough
                "https://www.youtube.com/watch?v=TAhbFRMURtg&list=WL&index=117&pp=gAQBiAQB",  // Time as explained by Brian Greene
                "https://www.youtube.com/watch?v=q3uXXh1sHcI&pp=ygUMYmFieSBwZW5ndWlu", // Baby penguin
                "https://www.youtube.com/watch?v=a9LR7s385sU&pp=ygUTamFwYW5lc2UgcmVzdGF1cmFudA%3D%3D", // Katsudon!
                "https://www.youtube.com/watch?v=bUmULlGACEI" // Dr. Michio Kaku Physics q&a
            };

            // Pick a random video
            string videoUrl = videos[random.Next(videos.Length)];

            // Open the selected video URL in the default web browser
            System.Diagnostics.Process.Start(videoUrl);
        }
    }
}
