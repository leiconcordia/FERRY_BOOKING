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
        private int? RouteID;
        public int OwnerID { get; set; }
        public AddRoute(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;
            RouteID = null;
            cbFerry.SelectedIndexChanged += cbFerry_SelectedIndexChanged; // <-- ADD THIS

            LoadFerriesDropdown();
        }
        public AddRoute(int routeID, int ferryID, int ownerID)
        {
            InitializeComponent();
            this.OwnerID = ownerID;         // ✔ set owner
            selectedFerryID = ferryID;
            RouteID = routeID;
            cbFerry.SelectedIndexChanged += cbFerry_SelectedIndexChanged; // <-- ADD THIS

            LoadFerriesDropdown();
            cbFerry.SelectedValue = selectedFerryID;

            LoadRouteData(routeID);
        }

        private void cbFerry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFerry.SelectedValue != null)
            {
                selectedFerryID = Convert.ToInt32(cbFerry.SelectedValue);
            }
        }




        private void LoadRouteData(int routeID)
        {
            DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();
            DataRow row = helper.GetRouteById(routeID);

            if (row != null)
            {
                tbOriginPort.Text = row["Origin"].ToString();
                tbDestinationPort.Text = row["Destination"].ToString();

                decimal distance = Convert.ToDecimal(row["Distance"]);
                nudDistance.Minimum = 0;            // set minimum
                nudDistance.Maximum = 10000;        // set maximum high enough
                nudDistance.DecimalPlaces = 2;      // optional, if you want decimals
                nudDistance.Increment = 0.5M;       // optional, for user increments
                nudDistance.Value = distance;

                // Duration field
                TimeSpan duration = TimeSpan.Parse(row["Duration"].ToString());
                nudHours.Value = duration.Hours;
                nudMin.Value = duration.Minutes;
            }
        }



        private void LoadFerriesDropdown()
        {
            try
            {
                DataTable dt = helper.LoadFerriesForOwner(OwnerID);

                cbFerry.DisplayMember = "FerryName";
                cbFerry.ValueMember = "FerryID";

                cbFerry.DataSource = dt;      // ← After Display/ValueMember
                cbFerry.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ferries: " + ex.Message);
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            string origin = tbOriginPort.Text.Trim();
            string destination = tbDestinationPort.Text.Trim();
            decimal distance = nudDistance.Value;
            TimeSpan duration = new TimeSpan((int)nudHours.Value, (int)nudMin.Value, 0);

            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Origin and destination cannot be empty.");
                return;
            }

            if (distance <= 0 || duration.TotalMinutes <= 0)
            {
                MessageBox.Show("Distance and duration must be greater than 0.");
                return;
            }

            FerryOwnerHelper helper = new FerryOwnerHelper();
            bool success;

            if (RouteID.HasValue) // Edit mode
            {
                // Update the existing route for the selected ferry
                success = helper.UpdateRoute(RouteID.Value, selectedFerryID, origin, destination, distance, duration);
            }
            else // Add mode
            {
                // Add a new route to the selected ferry
                success = helper.AddRouteToFerry(selectedFerryID, origin, destination, distance, duration);
            }

            if (success)
            {
                MessageBox.Show("Route saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save route.");
            }



        }



    }
}
