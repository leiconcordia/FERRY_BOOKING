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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }
        private Button activeButton = null;

        private void LoadUserControl(UserControl uc)
        {
            StaffPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            StaffPanel.Controls.Add(uc);
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

        private void StaffForm_Load(object sender, EventArgs e)
        {
            // Check if the panel is empty
            if (StaffPanel.Controls.Count == 0)
            {
                // Create an instance of your UserControl
                UC_Staff.Booking booking = new UC_Staff.Booking();

                // Make sure it fills the panel
                booking.Dock = DockStyle.Fill;

                // Add it to the panel
                StaffPanel.Controls.Add(booking);
                ActivateButton(navBooking);
            }
        }

        private void navBooking_Click(object sender, EventArgs e)
        {
            ActivateButton(navBooking);
            LoadUserControl(new UC_Staff.Booking());
        }

        private void navManageBookings_Click(object sender, EventArgs e)
        {
            ActivateButton(navManageBookings);
            LoadUserControl(new UC_Staff.ManageBookings());
        }

        private void navPassengerHistory_Click(object sender, EventArgs e)
        {
            ActivateButton(navPassengerHistory);
            LoadUserControl(new UC_Staff.PassengerHistory());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.StaffLoginForm slf = new Forms.StaffLoginForm();
            slf.Show();
        }
    }
}
