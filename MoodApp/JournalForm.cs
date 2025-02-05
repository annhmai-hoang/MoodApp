using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodApp
{
    public partial class JournalForm : Form
    {
        private string dbPath = "Data Source=moods.db;";
        private int selectedEntryID = -1;

        private int currentPage = 1; // Default to the first page
        private int pageSize = 10;   // Number of records per page
        private int totalRecords = 0; // Total number of records in the database
        private int totalPages = 0;   // Total number of pages

        public JournalForm()
        {
            InitializeComponent();
            LoadEntries();
        }


        // Load entries onto DataGrid
        private void LoadEntries()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                // Get the total number of records
                string countQuery = "SELECT COUNT(*) FROM JournalEntries WHERE UserID=@UserID";
                using (var countCommand = new SQLiteCommand(countQuery, connection))
                {
                    countCommand.Parameters.AddWithValue("@UserID", Login.LoggedInUserID);
                    totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
                }

                // Calculate total pages
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Calculate offset based on the current page
                int offset = (currentPage - 1) * pageSize;

                // Get the records for the current page
                string query = "SELECT ID, Date, Entry FROM JournalEntries WHERE UserID=@UserID ORDER BY Date DESC LIMIT @PageSize OFFSET @Offset";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", Login.LoggedInUserID);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Show date and time without seconds
                        foreach (DataRow row in dt.Rows)
                        {
                            DateTime date = Convert.ToDateTime(row["Date"]);
                            row["Date"] = date.ToString("yyyy-MM-dd HH:mm");
                        }

                        // Set the DataSource of the DataGridView
                        journalDataGridView.DataSource = dt;
                    }
                }
            }

            // Hide the 'ID' column from the DataGridView
            journalDataGridView.Columns["ID"].Visible = false;

            // Hide the blank column (row headers)
            journalDataGridView.RowHeadersVisible = false;

            // Adjust column width to fit content
            journalDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            journalDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            journalDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Allows text wrapping

            // Adjust specific column widths
            journalDataGridView.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            journalDataGridView.Columns["Entry"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Update pagination buttons
            UpdatePaginationButtons();
        }


        // Add new entry and update entry list
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEntry.Text))
            {
                MessageBox.Show("Please enter a journal entry.");
                return;
            }

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "INSERT INTO JournalEntries (UserID, Date, Entry) VALUES (@UserID, datetime('now'), @Entry)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", Login.LoggedInUserID);
                    command.Parameters.AddWithValue("@Entry", txtEntry.Text);
                    command.ExecuteNonQuery();
                }
            }

            txtEntry.Clear();
            LoadEntries();
        }


        // Update/Edit specific entry
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedEntryID == -1 || string.IsNullOrWhiteSpace(txtEntry.Text))
            {
                MessageBox.Show("Select an entry to edit.");
                return;
            }

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "UPDATE JournalEntries SET Entry=@Entry WHERE ID=@ID AND UserID=@UserID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Entry", txtEntry.Text);
                    command.Parameters.AddWithValue("@ID", selectedEntryID);
                    command.Parameters.AddWithValue("@UserID", Login.LoggedInUserID);
                    command.ExecuteNonQuery();
                }
            }

            txtEntry.Clear();
            selectedEntryID = -1;
            LoadEntries();
        }


        // Delete choosen entry
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEntryID == -1)
            {
                MessageBox.Show("Select an entry to delete.");
                return;
            }

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "DELETE FROM JournalEntries WHERE ID=@ID AND UserID=@UserID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", selectedEntryID);
                    command.Parameters.AddWithValue("@UserID", Login.LoggedInUserID);
                    command.ExecuteNonQuery();
                }
            }

            txtEntry.Clear();
            selectedEntryID = -1;
            LoadEntries();
        }

        // Let us know whether a cell is being clicked (this is for edit and delete)
        private void journalDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedEntryID = Convert.ToInt32(journalDataGridView.Rows[e.RowIndex].Cells["ID"].Value);
                txtEntry.Text = journalDataGridView.Rows[e.RowIndex].Cells["Entry"].Value.ToString();
            }
        }

        // Pagination
        private void UpdatePaginationButtons()
        {
            // Disable "Previous" button if on the first page
            btnPrevious.Enabled = currentPage > 1;

            // Disable "Next" button if on the last page
            btnNext.Enabled = currentPage < totalPages;

            // Update the page label
            lblPage.Text = $"Page {currentPage} of {totalPages}";
        }

        // Next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadEntries();
            }
        }

        // Prev page
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadEntries();
            }
        }

        
    }
}
