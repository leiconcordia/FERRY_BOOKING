using FERRY_BOOKING.DATABASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.Forms
{
    public partial class FerryOwnerLoginForm : Form
    {
        public FerryOwnerLoginForm()
        {
            InitializeComponent();
        }

        private void FerryOwnerLogin_Load(object sender, EventArgs e)
        {
            // ensure login panel shown on startup
            ShowLoginPanel();
            // apply initial layout
            FerryOwnerLogin_Resize(sender, e);
        }

        private void FerryOwnerLogin_Resize(object sender, EventArgs e)
        {
            try
            {
                if (cardPanel != null)
                {
                    cardPanel.Left = (this.ClientSize.Width - cardPanel.Width) / 2;
                    cardPanel.Top = Math.Max(10, (this.ClientSize.Height - cardPanel.Height) / 6);
                }
            }
            catch
            {
                // ignore design-time errors
            }
        }
        private void tabLoginButton_Click(object sender, EventArgs e)
        {
            ShowLoginPanel();
        }

        private void tabRegisterButton_Click(object sender, EventArgs e)
        {
            ShowRegisterPanel();
        }


        private void ShowLoginPanel()
        {
            try
            {
                if (loginPanel != null && registerPanel != null)
                {
                    loginPanel.Visible = true;
                    registerPanel.Visible = false;
                    // FIXED: Correct tab colors - Login active, Register inactive
                    tabLoginButton.BackColor = Color.Gainsboro;  // Active tab
                    tabRegisterButton.BackColor = Color.WhiteSmoke; // Inactive tab
                }
            }
            catch { }
        }

        private void ShowRegisterPanel()
        {
            try
            {
                if (loginPanel != null && registerPanel != null)
                {
                    loginPanel.Visible = false;
                    registerPanel.Visible = true;
                    // FIXED: Correct tab colors - Register active, Login inactive
                    tabLoginButton.BackColor = Color.WhiteSmoke; // Inactive tab
                    tabRegisterButton.BackColor = Color.Gainsboro;  // Active tab
                }
            }
            catch { }
        }



        private void btnSignIn_Click(object sender, EventArgs e)
        {
            FerryOwnerHelper helper = new FerryOwnerHelper();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(username))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = helper.ValidateLoginWithRole(username, password);

            if (role == "admin")
            {
                MessageBox.Show("Welcome Admin!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open admin form
            }
            else if (role == "staff")
            {
                MessageBox.Show("Welcome Staff!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open staff form
            }
            else if (role == "FerryOwner")
            {
                var userDetails = helper.GetUserDetailsByEmail(username);
                MessageBox.Show($"Welcome {userDetails.FirstName}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OwnerForm of = new OwnerForm(userDetails.UserID, username, userDetails.FirstName, userDetails.LastName, userDetails.CompanyName);
                of.FormClosed += (s, args) => this.Close();
                of.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // simple stub for register button - implement actual registration logic
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate all fields are filled
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtCompanyName.Text) ||
                    string.IsNullOrWhiteSpace(txtRegUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtRegPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtRegConfirm.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Missing Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate email format
                if (!IsValidEmail(txtRegUsername.Text))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate password match
                if (txtRegPassword.Text != txtRegConfirm.Text)
                {
                    MessageBox.Show("Passwords do not match. Please try again.", "Password Mismatch",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate password strength
                if (txtRegPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Weak Password",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create ferry owner helper instance
                FERRY_BOOKING.DATABASE.FerryOwnerHelper ferryOwnerHelper = new FERRY_BOOKING.DATABASE.FerryOwnerHelper();

                // Check if email already exists
                if (ferryOwnerHelper.EmailExists(txtRegUsername.Text.Trim()))
                {
                    MessageBox.Show("This email is already registered. Please use a different email.",
                                  "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Register the user
                bool success = ferryOwnerHelper.RegisterFerryOwner(
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtCompanyName.Text.Trim(),
                    txtRegUsername.Text.Trim(), // Using as email
                    txtRegPassword.Text
                );

                if (success)
                {
                    MessageBox.Show("Registration successful! You can now login with your credentials.",
                                  "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the form and switch to login panel
                    ClearRegisterForm();
                    ShowLoginPanel();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Registration Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                // Additional checks for more strict validation
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                if (!email.Contains("@"))
                    return false;

                // Check if domain has at least one dot
                string domain = email.Split('@')[1];
                if (!domain.Contains("."))
                    return false;

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Method to clear the register form
        private void ClearRegisterForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCompanyName.Clear();
            txtRegUsername.Clear();
            txtRegPassword.Clear();
            txtRegConfirm.Clear();

            // Set focus to first field
            txtFirstName.Focus();
        }
    }
}
