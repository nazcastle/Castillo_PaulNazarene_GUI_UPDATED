 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Castillo_PaulNazarene_GUI
{
    public partial class LoginForm : Form
    {
        private string validUsername = "nazcastle";
        private string validPassword = "password";
        private int loginAttempts = 0;

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

            if (username == validUsername && password == validPassword)
            {
                // Successful login
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentForm studentForm = new StudentForm();
                this.Hide();
                studentForm.Show();
            }
            else
            {
                // Failed login
                string errorMessage = "";
                if (username != validUsername && password != validPassword)
                {
                    errorMessage = "Incorrect Username and Password.";
                }
                else if (username != validUsername)
                {
                    errorMessage = "Incorrect Username.";
                }
                else if (password != validPassword)
                {
                    errorMessage = "Incorrect Password.";
                }
                MessageBox.Show(errorMessage + $"\nAttempt: {loginAttempts} of 5", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Clear password field after failed attempt
                PasswordTextBox.Clear();
                PasswordTextBox.Focus(); // Set focus back to password textbox for next attempt
            }
        }
    }
}
