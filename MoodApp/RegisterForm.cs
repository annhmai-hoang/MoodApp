using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodApp
{
    public partial class RegisterForm : Form
    {
        private string connectionString = "Data Source=moods.db;Version=3;";
        public RegisterForm()
        {
            InitializeComponent();
        }

        // Insert new user into DB, ensure usesrname's uniqueness
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            string hashedPassword = HashPassword(password);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Check if username already exists
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SQLiteCommand cmd = new SQLiteCommand(checkUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose another.");
                        return;
                    }
                }

                // Insert new user
                string insertQuery = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Registration successful!");
            this.Close();  // Close the registration form after success
        }


        // Hashing for better security
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        
    }
}
