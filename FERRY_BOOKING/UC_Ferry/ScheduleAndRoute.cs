using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace FERRY_BOOKING.UC_Ferry
{
    public partial class ScheduleAndRoute : UserControl
    {

        public int OwnerID { get; set; }


        public ScheduleAndRoute(int OwnerID)
        {
            InitializeComponent();

            this.OwnerID = OwnerID;
        }
        private Button activeButton = null;
        private void LoadUserControl(UserControl uc)
        {
            PanelRoutesAndSchedules.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            PanelRoutesAndSchedules.Controls.Add(uc);
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
        private void ScheduleAndRoute_Load(object sender, EventArgs e)
        {
            // Check if the panel is empty
            if (PanelRoutesAndSchedules.Controls.Count == 0)
            {
                // Create an instance of your UserControl
                UC_Ferry.Routes r = new UC_Ferry.Routes(OwnerID);

                // Make sure it fills the panel
                r.Dock = DockStyle.Fill;

                // Add it to the panel
                PanelRoutesAndSchedules.Controls.Add(r);
                ActivateButton(btnRoute);
            }
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            ActivateButton(btnRoute);
            LoadUserControl(new UC_Ferry.Routes(OwnerID));
        }

        private void btnSched_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSched);
            LoadUserControl(new UC_Ferry.Schedules(OwnerID));
        }
    }
}
