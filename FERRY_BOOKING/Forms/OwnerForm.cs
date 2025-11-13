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
    public partial class OwnerForm : Form
    {
        public int OwnerID { get; set; }
        public string UserEmail { get; set; }
        public string CompanyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public OwnerForm(int OwnerID, string email, string firstName, string lastName, string companyName)
        {
            InitializeComponent();

            lblOwnerName.Text = $"{firstName} {lastName}";
            this.OwnerID = OwnerID;
            this.UserEmail = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.CompanyName = companyName;

        }


        private Button activeButton = null;

        private void LoadUserControl(UserControl uc)
        {
            FerryOwnerPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            FerryOwnerPanel.Controls.Add(uc);
        }



        private void ActivateButton(Button clickedButton)
        {
            // Reset previous active button
            if (activeButton != null)
            {
                activeButton.BackColor = SystemColors.Control; // default button color
                activeButton.ForeColor = Color.Black;          // reset text color
            }

            // Highlight the new active button
            activeButton = clickedButton;
            activeButton.BackColor = SystemColors.ButtonHighlight;   // blue highlight color
            activeButton.ForeColor = Color.Black;              // white text for contrast
        }



        private void FerryOwnerForm_Load(object sender, EventArgs e)
        {
            // Check if the panel is empty
            if (FerryOwnerPanel.Controls.Count == 0)
            {
                // Create an instance of your UserControl
                UC_Ferry.Dashboard dashboard = new UC_Ferry.Dashboard();

                // Make sure it fills the panel
                dashboard.Dock = DockStyle.Fill;

                // Add it to the panel
                FerryOwnerPanel.Controls.Add(dashboard);
                ActivateButton(navDashboard);
            }
        }

        private void navDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(navDashboard);
            LoadUserControl(new UC_Ferry.Dashboard());
        }

        private void navFerries_Click(object sender, EventArgs e)
        {
            ActivateButton(navFerries);
            LoadUserControl(new UC_Ferry.MyFerries(OwnerID, UserEmail, CompanyName));
        }

        private void navSchedule_Click(object sender, EventArgs e)
        {
            ActivateButton(navSchedule);
            LoadUserControl(new UC_Ferry.ScheduleAndRoute(OwnerID));
        }

        private void navSummary_Click(object sender, EventArgs e)
        {
            ActivateButton(navSummary);
            LoadUserControl(new UC_Ferry.Summary());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FerryOwnerLoginForm folf = new FerryOwnerLoginForm();
            folf.Show();
        }
    }
}
