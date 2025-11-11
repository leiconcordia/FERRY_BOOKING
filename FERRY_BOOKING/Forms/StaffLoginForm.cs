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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username.Equals("staff") && password.Equals("123"))
            {
                this.Hide();
                Forms.StaffForm sf = new Forms.StaffForm();
                sf.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }


    }
}
