using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Castillo_PaulNazarene_GUI
{
    public partial class LoginForm : Form
    {
        private int loginAttempts = 0;
        private string connectionString = "server=localhost;database=student_db;user=root;password=12345";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            loginAttempts++;
            if (loginAttempts > 5)
            {
                MessageBox.Show("Too many failed login attempts. Please reset your password using the link below.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Password reset link (for display only)
                MessageBox.Show("Reset Password Link: www.example.com/resetpassword", "Reset Password Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // Or disable login button and show reset link
                return;
            }

            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM students WHERE username = @username AND password = MD5(@password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {

                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StudentForm studentForm = new StudentForm();
                            this.Hide();
                            studentForm.Show();
                        }
                        else
                        {

                            string errorMessage = "Invalid username or password.";
                            MessageBox.Show(errorMessage + $"\nAttempt: {loginAttempts} of 5", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            PasswordTextBox.Clear();
                            PasswordTextBox.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}