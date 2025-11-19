using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.UC_Ferry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace FERRY_BOOKING.Dialogs
{
    public partial class AddSchedule : Form
    {
        private int OwnerID;
        public AddSchedule(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;

            LoadFerriesDropdown();
            InitializeDayButtons();
        }

        private void LoadFerriesDropdown()
        {
            DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();

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


        private void cbFerry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFerry.SelectedItem == null) return;

            DataRowView drv = cbFerry.SelectedItem as DataRowView;
            if (drv == null) return;

            int ferryID = Convert.ToInt32(drv["FerryID"]);

            // Load routes & floors
            LoadRoutesForFerry(ferryID);
            LoadFloors(ferryID);
        }


        private void cbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoute.SelectedItem == null) return;

            DataRowView drv = cbRoute.SelectedItem as DataRowView;
            if (drv == null) return;

            int routeID = Convert.ToInt32(drv["RouteID"]);

        }
        private void LoadRoutesForFerry(int ferryID)
        {
            if (ferryID <= 0) return;

            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

            DataTable dtRoutes = db.ExecuteDataTable(@"
        SELECT r.RouteID, r.Origin + ' -> ' + r.Destination AS Route
        FROM FerryRoute fr
        INNER JOIN Route r ON r.RouteID = fr.RouteID
        WHERE fr.FerryID = @FerryID",
                new SqlParameter("@FerryID", ferryID)
            );

            cbRoute.DataSource = dtRoutes;
            cbRoute.DisplayMember = "Route";
            cbRoute.ValueMember = "RouteID";
            cbRoute.SelectedIndex = -1; // no route selected initially
        }








        private void LoadFloors(int ferryID)
        {
            flpFloorPrice.FlowDirection = FlowDirection.LeftToRight;
            flpFloorPrice.WrapContents = true;
            flpFloorPrice.Controls.Clear();

            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();
            DataTable dtFloors = db.ExecuteDataTable(@"
        SELECT FerryID, FloorNumber
        FROM FerryFloor
        WHERE FerryID=@FerryID
        ORDER BY FloorNumber",
                new SqlParameter("@FerryID", ferryID));

            foreach (DataRow row in dtFloors.Rows)
            {
                int floorNumber = (int)row["FloorNumber"];

                Label lbl = new Label
                {
                    Text = $"Floor {floorNumber} Price:",
                    AutoSize = true
                };

                NumericUpDown nud = new NumericUpDown
                {
                    Name = $"nudPrice_{ferryID}_{floorNumber}",
                    Minimum = 100,
                    Maximum = 10000,
                    DecimalPlaces = 2,
                    Width = 80
                };

                // Create a small container to keep label + nud together
                Panel p = new Panel
                {
                    Width = 200,
                    Height = 40
                };

                lbl.Location = new Point(0, 10);
                nud.Location = new Point(120, 5);

                p.Controls.Add(lbl);
                p.Controls.Add(nud);

                flpFloorPrice.Controls.Add(p);
            }
        }


        private void dtpDepartureTime_ValueChanged(object sender, EventArgs e)
        {
            if (cbRoute.SelectedValue == null) return;

            int routeID = (int)cbRoute.SelectedValue;
            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

            object obj = db.ExecuteScalar(
                "SELECT Duration FROM Route WHERE RouteID=@RouteID",
                new SqlParameter[] { new SqlParameter("@RouteID", routeID) }
            );

            if (obj == null || obj == DBNull.Value)
                return;

            TimeSpan duration;
            if (obj is TimeSpan ts)
                duration = ts;
            else if (!TimeSpan.TryParse(obj.ToString(), out duration))
            {
                MessageBox.Show("Invalid duration in database.");
                return;
            }

            dtpArrivalTime.Value = dtpDepartureTime.Value.Add(duration);
            dtpArrivalTime.Enabled = false;
        }



















        private void btnMon_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnMon);
        }

        private void btnTue_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnTue);
        }

        private void btnWed_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnWed);
        }

        private void btnThu_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnThu);
        }

        private void btnFri_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnFri);
        }

        private void btnSat_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnSat);
        }

        private void btnSun_Click(object sender, EventArgs e)
        {
            ToggleButtonSelection(btnSun);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Button[] allDayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };

            // Check if any button is not selected
            bool anyUnselected = allDayButtons.Any(btn => btn.BackColor != Color.White);

            if (anyUnselected)
            {
                // Select all
                foreach (Button btn in allDayButtons)
                {
                    btn.BackColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.Blue;
                }
                btnSelectAll.Text = "Clear All";
            }
            else
            {
                // Clear all
                foreach (Button btn in allDayButtons)
                {
                    btn.BackColor = Color.LightGray;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                }
                btnSelectAll.Text = "Select All";
            }
        }

        // Helper method to toggle individual button selection
        private void ToggleButtonSelection(Button button)
        {
            if (button.BackColor == Color.LightGray)
            {
                // Select - change to white
                button.BackColor = Color.White;
                button.FlatAppearance.BorderColor = Color.Blue;
            }
            else
            {
                // Deselect - change back to light gray
                button.BackColor = Color.LightGray;
                button.FlatAppearance.BorderColor = Color.Gray;
            }

            // Update Select All button text based on current selection
            UpdateSelectAllButtonText();
        }

        // Method to update Select All button text
        private void UpdateSelectAllButtonText()
        {
            Button[] allDayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };
            bool allSelected = allDayButtons.All(btn => btn.BackColor == Color.White);

            btnSelectAll.Text = allSelected ? "Clear All" : "Select All";
        }

        // Method to get selected days as string (e.g., "MON,TUE,WED")
        public string GetSelectedDays()
        {
            List<string> selectedDays = new List<string>();

            if (btnMon.BackColor == Color.White) selectedDays.Add("Monday");
            if (btnTue.BackColor == Color.White) selectedDays.Add("Tuesday");
            if (btnWed.BackColor == Color.White) selectedDays.Add("Wednesday");
            if (btnThu.BackColor == Color.White) selectedDays.Add("Thursday");
            if (btnFri.BackColor == Color.White) selectedDays.Add("Friday");
            if (btnSat.BackColor == Color.White) selectedDays.Add("Saturday");
            if (btnSun.BackColor == Color.White) selectedDays.Add("Sunday"); // FIXED

            return string.Join(",", selectedDays);
        }

        // Method to set selected days from string
        public void SetSelectedDays(string daysString)
        {
            if (string.IsNullOrEmpty(daysString)) return;

            string[] days = daysString.Split(',');

            // Reset all buttons to unselected first
            ResetAllDayButtons();

            // Select the specified days
            foreach (string day in days)
            {
                switch (day.Trim().ToUpper())
                {
                    case "Monday": btnMon.BackColor = Color.White; break;
                    case "Tuesday": btnTue.BackColor = Color.White; break;
                    case "Wednesday": btnWed.BackColor = Color.White; break;
                    case "Thursday": btnThu.BackColor = Color.White; break;
                    case "Friday": btnFri.BackColor = Color.White; break;
                    case "Saturday": btnSat.BackColor = Color.White; break;
                    case "Sunday": btnSun.BackColor = Color.White; break;
                    default: break; // ignore unknown
                }
            }

            UpdateSelectAllButtonText();
        }


        // Reset all buttons to unselected
        private void ResetAllDayButtons()
        {
            Button[] dayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };
            foreach (Button btn in dayButtons)
            {
                btn.BackColor = Color.LightGray;
                btn.FlatAppearance.BorderColor = Color.Gray;
            }
        }

        // Initialize the buttons (call this in form load)
        private void InitializeDayButtons()
        {
            // Set initial button properties
            Button[] dayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };

            foreach (Button btn in dayButtons)
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Gray;
            }

            // Set Select All button
            btnSelectAll.Text = "Select All";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            // ================================
            // 1. VALIDATE REQUIRED FIELDS
            // ================================
            if (cbFerry.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a ferry.");
                return;
            }

            if (cbRoute.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a route.");
                return;
            }

            if (cbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.");
                return;
            }

            string operatingDays = GetSelectedDays();
            if (string.IsNullOrWhiteSpace(operatingDays))
            {
                MessageBox.Show("Please select at least one operating day.");
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be before start date.");
                return;
            }

            DateTime departure = dtpDepartureTime.Value;
            DateTime arrival = dtpArrivalTime.Value;

            int ferryID = Convert.ToInt32(cbFerry.SelectedValue);
            string ferryName = cbFerry.Text;

            int routeID = Convert.ToInt32(cbRoute.SelectedValue);
            string routeName = cbRoute.Text;
            bool isActive = cbStatus.SelectedItem.ToString() == "Active";

            // ================================
            // 2. COLLECT FLOOR PRICES
            // ================================
            Dictionary<int, decimal> floorPrices = new Dictionary<int, decimal>();
            foreach (Control ctrl in flpFloorPrice.Controls)
            {
                if (ctrl is Panel panel)
                {
                    foreach (Control c in panel.Controls)
                    {
                        if (c is NumericUpDown nud)
                        {
                            string[] parts = nud.Name.Split('_');
                            int floorNumber = Convert.ToInt32(parts[2]);
                            floorPrices[floorNumber] = nud.Value;
                        }
                    }
                }
            }

            // ================================
            // 3. BUILD SUMMARY STRING
            // ================================
            string summary =
                $"FERRY INFORMATION\n" +
                $"• Ferry: {ferryName} (ID: {ferryID})\n" +
                $"• Route: {routeName} (ID: {routeID})\n\n" +

                $"SCHEDULE PERIOD\n" +
                $"• Start Date: {startDate:MMMM dd, yyyy}\n" +
                $"• End Date: {endDate:MMMM dd, yyyy}\n\n" +

                $"OPERATING DAYS\n" +
                $"• {operatingDays}\n\n" +

                $"TIMES\n" +
                $"• Departure Time: {departure:hh:mm tt}\n" +
                $"• Arrival Time: {arrival:hh:mm tt}\n\n" +

                $"FLOOR PRICES\n";

            foreach (var fp in floorPrices)
                summary += $"• Floor {fp.Key}: ₱{fp.Value}\n";

            summary += $"Status: {(isActive ? "Active" : "Inactive")}";

            // ================================
            // 4. CONFIRMATION DIALOG
            // ================================
            DialogResult result = MessageBox.Show(
                summary,
                "Confirm Schedule Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                MessageBox.Show("Action cancelled.");
                return;
            }

            // ================================
            // 5. DATABASE INSERT
            // ================================
            try
            {
                DATABASE.FerryOwnerHelper db = new DATABASE.FerryOwnerHelper();

                // 5.1 Insert Schedule
                int scheduleID = db.InsertSchedule(
                    ferryID,
                    routeID,
                    departure.TimeOfDay,
                    arrival.TimeOfDay,
                    operatingDays,
                    startDate,
                    endDate,
                    isActive
                );

                // 5.2 Generate Trips based on schedule
                List<int> tripIDs = db.GenerateTripsFromSchedule(
                    scheduleID,
                    ferryID,
                    routeID,
                    operatingDays,
                    startDate,
                    endDate,
                    departure.TimeOfDay,
                    arrival.TimeOfDay
                );

                // 5.3 Insert Floor Prices for each Trip
                foreach (int tripID in tripIDs)
                {
                    foreach (var fp in floorPrices)
                    {
                        db.InsertTripFloorPrice(tripID, ferryID, fp.Key, fp.Value);
                    }
                }

                MessageBox.Show($"Schedule created successfully!\nGenerated {tripIDs.Count} trips.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
