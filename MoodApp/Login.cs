using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodApp
{
    public partial class Login : Form
    {
        private readonly string dbPath = "Data Source=moods.db;Version=3;";

        public static int LoggedInUserID { get; private set; } // Global user ID

        public Login()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        // Initialize DB including tables for user's info and mood/journal entries and affirmation messages
        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                string sqlScript = File.ReadAllText("affirmations.sql"); // see sql script
                using (var command = new SQLiteCommand(sqlScript, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }


        // Handle login, match username-password, save UserID for user-specific data/info
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                // Retrieve the stored password hash for the given username
                string query = "SELECT ID, PasswordHash FROM Users WHERE Username = @Username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row exists
                        {
                            int userId = reader.GetInt32(0);  // Retrieve UserID
                            string storedHashedPassword = reader.GetString(1); // Retrieve hashed password

                            if (VerifyPassword(password, storedHashedPassword))
                            {
                                LoggedInUserID = userId; // Store the correct user ID globally
                                this.Hide();  // Hide login form
                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
        }


        // Verify password against stored hashed passwords
        private bool VerifyPassword(string password, string storedHash)
        {
            // de-Hashing
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString() == storedHash;
            }
        }


        // Redirect to register
        private void lblRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        // Make sure that when Login is closed, everything closes
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Ensures all threads and forms are closed properly
        }
    }
}
