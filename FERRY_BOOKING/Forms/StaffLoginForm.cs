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
    public partial class StaffLoginForm : Form
    {
        public StaffLoginForm()
        {
            InitializeComponent();
        }


        private void StaffLoginForm_Load(object sender, EventArgs e)
        {
            // ✅ This runs when the form first loads
            CenterCardPanel(); // optional: you can call your centering logic here
        }

        private void StaffLoginForm_Resize(object sender, EventArgs e)
        {
            // ✅ This runs whenever the window is resized
            CenterCardPanel(); // keep the layout centered when resizing
        }

        // Helper method to center the card panel
        private void CenterCardPanel()
        {
            if (cardPanel != null)
            {
                int cx = Math.Max(0, (this.ClientSize.Width - cardPanel.Width) / 2);
                int cy = Math.Max(0, (this.ClientSize.Height - cardPanel.Height) / 2);
                cardPanel.Location = new Point(cx, cy);
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            StaffHelper helper = new StaffHelper();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = helper.ValidateLogin(username, password);

            if (role == "admin")
            {
                MessageBox.Show("not welcome", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (role == "staff")
            {
                MessageBox.Show("Welcome Staff!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaffForm staffForm = new StaffForm();
                staffForm.FormClosed += (s, args) => this.Close();
                staffForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
