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

namespace FERRY_BOOKING.Dialogs
{
    public partial class AddRoute : Form
    {
        private DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();

        private int selectedFerryID = 0;
        private string selectedFerryName = "";
        public int OwnerID { get; set; }
        public AddRoute(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;

            LoadFerriesDropdown();
        }

        private void LoadFerriesDropdown()
        {
            try
            {
                DataTable dt = helper.LoadFerriesForOwner(OwnerID);

                cbFerry.DataSource = dt;
                cbFerry.DisplayMember = "FerryName";
                cbFerry.ValueMember = "FerryID";
                cbFerry.SelectedIndex = -1; // no selection initially
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ferries: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            // Validate ferry selection
            if (cbFerry.SelectedItem == null)
            {
                MessageBox.Show("Please select a ferry.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected ferry
            DataRowView row = cbFerry.SelectedItem as DataRowView;
            int selectedFerryID = 0;
            string selectedFerryName = "";

            if (row != null)
            {
                selectedFerryID = Convert.ToInt32(row["FerryID"]);
                selectedFerryName = row["FerryName"].ToString();
            }
            else
            {
                selectedFerryName = cbFerry.SelectedItem.ToString();
                // If needed, you can map the name to an ID from a dictionary
            }

            // Get route details
            string originPort = tbOriginPort.Text.Trim();
            string destinationPort = tbDestinationPort.Text.Trim();
            decimal distance = nudDistance.Value;
            TimeSpan duration = TimeSpan.FromHours((double)nudDuration.Value);

            // Validate input
            if (string.IsNullOrEmpty(originPort) || string.IsNullOrEmpty(destinationPort))
            {
                MessageBox.Show("Origin and destination ports cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (distance <= 0)
            {
                MessageBox.Show("Distance must be greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (duration.TotalMinutes <= 0)
            {
                MessageBox.Show("Duration must be greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Now you have all values ready: selectedFerryID, originPort, destinationPort, distance, duration

            // For now, just display them
            MessageBox.Show(
                $"Ferry: {selectedFerryName} (ID: {selectedFerryID})\n" +
                $"Origin: {originPort}\nDestination: {destinationPort}\n" +
                $"Distance: {distance} km\nDuration: {duration}",
                "Route Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Later, call your helper method to insert into database, e.g.:
            // helper.AddRoute(selectedFerryID, originPort, destinationPort, distance, duration);
        }


    }
}
