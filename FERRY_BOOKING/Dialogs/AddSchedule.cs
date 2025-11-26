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
        private int? EditingScheduleID = null; // null => create mode, otherwise edit mode

        public AddSchedule(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;

            LoadFerriesDropdown();
            InitializeDayButtons();
        }

        // New constructor to open the dialog in Edit mode and populate fields
        public AddSchedule(int OwnerID, int scheduleID) : this(OwnerID)
        {
            this.EditingScheduleID = scheduleID;

            // Update UI to reflect edit mode
            this.lblTitle.Text = "Edit Schedule";
            this.lblSubtitle.Text = "Modify schedule details";
            this.btnAddSchedule.Text = "Save";

            LoadScheduleForEdit(scheduleID);
        }

        private void LoadScheduleForEdit(int scheduleID)
        {
            try
            {
                DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

                string query = @"
                    SELECT s.ScheduleID, s.FerryID, s.RouteID, s.DepartureTime, s.ArrivalTime,
                           s.DaysOfWeek, s.StartDate, s.EndDate, s.IsActive
                    FROM Schedule s
                    WHERE s.ScheduleID = @ScheduleID
                ";

                SqlParameter[] prms = { new SqlParameter("@ScheduleID", scheduleID) };
                SqlParameter[] pricePrms = { new SqlParameter("@ScheduleID", scheduleID) };
                DataTable dt = db.ExecuteDataTable(query, prms);
                

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Schedule not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dt.Rows[0];

                int ferryID = Convert.ToInt32(row["FerryID"]);
                int routeID = Convert.ToInt32(row["RouteID"]);
                TimeSpan departure = (TimeSpan)row["DepartureTime"];
                TimeSpan arrival = (TimeSpan)row["ArrivalTime"];
                string daysOfWeek = row["DaysOfWeek"].ToString();
                DateTime startDate = Convert.ToDateTime(row["StartDate"]);
                DateTime endDate = Convert.ToDateTime(row["EndDate"]);
                bool isActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]);

                // Ensure ferries dropdown is loaded (constructor already did this)
                if (cbFerry.DataSource == null)
                    LoadFerriesDropdown();

                // Select ferry (this will trigger routes+floors load via SelectedIndexChanged handler)
                cbFerry.SelectedValue = ferryID;

                // Force loading routes explicitly and select route
                LoadRoutesForFerry(ferryID);
                if (cbRoute.DataSource != null)
                {
                    try { cbRoute.SelectedValue = routeID; }
                    catch { cbRoute.SelectedIndex = -1; }
                }

                // Fill date/time and status
                dtpDepartureTime.Value = DateTime.Today.Add(departure);
                dtpArrivalTime.Value = DateTime.Today.Add(arrival);
                dtpStartDate.Value = startDate;
                dtpEndDate.Value = endDate;
                cbStatus.SelectedItem = isActive ? "Active" : "Inactive";

                // Set days buttons
                SetSelectedDays(daysOfWeek);

                // Ensure floor controls are loaded for selected ferry
                LoadFloors(ferryID);

                // Try to populate floor prices using TripFloorPrice for any trip in this schedule
                try
                {
                    string priceQuery = @"
                        SELECT tfp.FloorNumber, tfp.Price
                        FROM TripFloorPrice tfp
                        INNER JOIN Trip t ON tfp.TripID = t.TripID
                        WHERE t.ScheduleID = @ScheduleID
                    ";
                    DataTable dtPrices = db.ExecuteDataTable(priceQuery, pricePrms);

                    foreach (DataRow pRow in dtPrices.Rows)
                    {
                        int floorNumber = Convert.ToInt32(pRow["FloorNumber"]);
                        decimal price = Convert.ToDecimal(pRow["Price"]);

                        // Find nud by generated name pattern: nudPrice_{ferryID}_{floorNumber}
                        string nudName = $"nudPrice_{ferryID}_{floorNumber}";

                        foreach (Control ctrl in flpFloorPrice.Controls)
                        {
                            if (ctrl is Panel panel)
                            {
                                foreach (Control c in panel.Controls)
                                {
                                    if (c is NumericUpDown nud && nud.Name == nudName)
                                    {
                                        nud.Value = Math.Min(nud.Maximum, Math.Max(nud.Minimum, price));
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // Non-fatal - floor prices may not be present; ignore
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule for edit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void LoadScheduleDetails(int scheduleID)
        {
            DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();

            try
            {
                // 1. Load schedule basic info
                DataRow schedule = helper.GetScheduleById(scheduleID);

                if (schedule == null)
                {
                    MessageBox.Show("Schedule not found!");
                    this.Close();
                    return;
                }

                // Use DataRow["ColumnName"] instead of properties
                cbFerry.SelectedValue = Convert.ToInt32(schedule["FerryID"]);
                cbRoute.SelectedValue = Convert.ToInt32(schedule["RouteID"]);

                // Schedule times stored as TimeSpan
                TimeSpan departureTime = (TimeSpan)schedule["DepartureTime"];
                TimeSpan arrivalTime = (TimeSpan)schedule["ArrivalTime"];
                dtpDepartureTime.Value = DateTime.Today.Add(departureTime);
                dtpArrivalTime.Value = DateTime.Today.Add(arrivalTime);

                // Status
                cbStatus.SelectedItem = Convert.ToBoolean(schedule["IsActive"]) ? "Active" : "Inactive";

                // 2. Load operating days
                string operatingDays = schedule["DaysOfWeek"].ToString(); // e.g., "Mon,Wed,Fri"
                SetSelectedDays(operatingDays);

                // 3. Load floor prices
                LoadFloors(Convert.ToInt32(schedule["FerryID"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //private void ValidateDepartureTime()
        //{
        //    if (cbFerry.SelectedIndex == -1)
        //    {
               
        //        return;
        //    }

        //    // Safely get ferry ID
        //    int ferryID = Convert.ToInt32(((DataRowView)cbFerry.SelectedItem)["FerryID"]);
        //    string ferryName = ((DataRowView)cbFerry.SelectedItem)["FerryName"].ToString();

        //    // Route
        //    if (cbRoute.SelectedIndex == -1)
        //    {
                
        //        return;
        //    }
        //    int routeID = Convert.ToInt32(((DataRowView)cbRoute.SelectedItem)["RouteID"]);
        //    string routeName = ((DataRowView)cbRoute.SelectedItem)["Route"].ToString();

        //    // Get schedule start/end dates from DateTimePickers
        //    DateTime startDate = dtpStartDate.Value.Date;
        //    DateTime endDate = dtpEndDate.Value.Date;

        //    // Store original trip duration
        //    TimeSpan originalDuration = dtpArrivalTime.Value - dtpDepartureTime.Value;

        //    FerryOwnerHelper db = new FerryOwnerHelper();
        //    TimeSpan earliest = db.GetEarliestAvailableDeparture(ferryID, routeID, startDate, endDate);

        //    if (earliest != TimeSpan.Zero && dtpDepartureTime.Value.TimeOfDay < earliest)
        //    {
        //        MessageBox.Show(
        //            $"This ferry already has trips scheduled.\n" +
        //            $"Earliest possible departure is {earliest:hh\\:mm}."
        //        );

        //        // Automatically set the departure to earliest allowed
        //        dtpDepartureTime.Value = dtpDepartureTime.Value.Date + earliest;

        //        // Adjust arrival to maintain original duration
        //        dtpArrivalTime.Value = dtpDepartureTime.Value + originalDuration;
        //    }
        //}




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
            if (cbRoute.SelectedItem == null) return;

            DataRowView drv = cbRoute.SelectedItem as DataRowView;
            if (drv == null) return;

            int routeID = Convert.ToInt32(drv["RouteID"]);
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


        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Start date cannot be after end date.");
                return;
            }
            UpdateDayButtonsForDateRange(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end date >= start date
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be before start date.");
                dtpEndDate.Value = dtpStartDate.Value;
                return;
            }

            UpdateDayButtonsForDateRange(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }








        private void UpdateDayButtonsForDateRange(DateTime startDate, DateTime endDate)
        {
            // Reset all buttons first
            ResetAllDayButtons();

            Button[] dayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };

            // Map buttons to DayOfWeek
            Dictionary<Button, DayOfWeek> buttonDays = new Dictionary<Button, DayOfWeek>()
    {
        { btnMon, DayOfWeek.Monday },
        { btnTue, DayOfWeek.Tuesday },
        { btnWed, DayOfWeek.Wednesday },
        { btnThu, DayOfWeek.Thursday },
        { btnFri, DayOfWeek.Friday },
        { btnSat, DayOfWeek.Saturday },
        { btnSun, DayOfWeek.Sunday }
    };

            foreach (var kvp in buttonDays)
            {
                Button btn = kvp.Key;
                DayOfWeek day = kvp.Value;

                // Check if this day exists within startDate -> endDate
                bool dayInRange = false;
                for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    if (d.DayOfWeek == day)
                    {
                        dayInRange = true;
                        break;
                    }
                }

                if (dayInRange)
                {
                    btn.Enabled = true; // selectable
                    btn.BackColor = Color.LightGray;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                }
                else
                {
                    btn.Enabled = false; // disable
                    btn.BackColor = Color.DarkGray;
                    btn.FlatAppearance.BorderColor = Color.DarkGray;
                }
            }

            // Update Select All button state
            UpdateSelectAllButtonText();
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

            // Only consider enabled buttons
            bool anyUnselected = allDayButtons.Any(btn => btn.Enabled && btn.BackColor != Color.White);

            foreach (Button btn in allDayButtons)
            {
                if (!btn.Enabled) continue;

                if (anyUnselected)
                {
                    btn.BackColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.Blue;
                }
                else
                {
                    btn.BackColor = Color.LightGray;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                }
            }

            btnSelectAll.Text = anyUnselected ? "Clear All" : "Select All";
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

            // Only include buttons that are enabled and selected (white)
            if (btnMon.Enabled && btnMon.BackColor == Color.White) selectedDays.Add("Monday");
            if (btnTue.Enabled && btnTue.BackColor == Color.White) selectedDays.Add("Tuesday");
            if (btnWed.Enabled && btnWed.BackColor == Color.White) selectedDays.Add("Wednesday");
            if (btnThu.Enabled && btnThu.BackColor == Color.White) selectedDays.Add("Thursday");
            if (btnFri.Enabled && btnFri.BackColor == Color.White) selectedDays.Add("Friday");
            if (btnSat.Enabled && btnSat.BackColor == Color.White) selectedDays.Add("Saturday");
            if (btnSun.Enabled && btnSun.BackColor == Color.White) selectedDays.Add("Sunday");

            return string.Join(",", selectedDays);
        }


        // Method to set selected days from string
        public void SetSelectedDays(string daysString)
        {
            if (string.IsNullOrEmpty(daysString)) return;

            string[] days = daysString.Split(',');

            // Reset all buttons to unselected first
            ResetAllDayButtons();

            foreach (string day in days)
            {
                string d = day.Trim();

                switch (d.ToUpper())
                {
                    case "MONDAY": if (btnMon.Enabled) { btnMon.BackColor = Color.White; btnMon.FlatAppearance.BorderColor = Color.Blue; } break;
                    case "TUESDAY": if (btnTue.Enabled) { btnTue.BackColor = Color.White; btnTue.FlatAppearance.BorderColor = Color.Blue; } break;
                    case "WEDNESDAY": if (btnWed.Enabled) { btnWed.BackColor = Color.White; btnWed.FlatAppearance.BorderColor = Color.Blue; } break;
                    case "THURSDAY": if (btnThu.Enabled) { btnThu.BackColor = Color.White; btnThu.FlatAppearance.BorderColor = Color.Blue; } break;
                    case "FRIDAY": if (btnFri.Enabled) { btnFri.BackColor = Color.White; btnFri.FlatAppearance.BorderColor = Color.Blue; } break;
                    case "SATURDAY": if (btnSat.Enabled) { btnSat.BackColor = Color.White; btnSat.FlatAppearance.BorderColor = Color.Blue; } break;
                    case "SUNDAY": if (btnSun.Enabled) { btnSun.BackColor = Color.White; btnSun.FlatAppearance.BorderColor = Color.Blue; } break;
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
            // 2. CHECK FOR CONFLICTING TRIPS - IMMEDIATE ABORT
            // ================================
            DATABASE.FerryOwnerHelper db = new DATABASE.FerryOwnerHelper();

            var (hasConflict, conflictMessage, conflictDetails) = db.CheckTripConflicts(
                ferryID,
                routeID,
                startDate,
                endDate,
                operatingDays,
                departure.TimeOfDay,
                arrival.TimeOfDay,
                EditingScheduleID // Exclude current schedule if editing
            );

            if (hasConflict)
            {
                // Show conflict dialog with details
                MessageBox.Show(
                    conflictMessage,
                    "⚠️ Schedule Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                // Optional: Show detailed conflict grid
                if (conflictDetails.Rows.Count > 0)
                {
                    DialogResult showDetails = MessageBox.Show(
                        "Would you like to view detailed conflict information?",
                        "View Conflicts",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (showDetails == DialogResult.Yes)
                    {
                        ShowConflictDetailsDialog(conflictDetails);
                    }
                }

                // ABORT - Do not proceed with schedule creation
                return;
            }

            // ================================
            // 3. COLLECT FLOOR PRICES
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
            // 4. BUILD SUMMARY STRING
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

            summary += $"\nStatus: {(isActive ? "Active" : "Inactive")}";

            // ================================
            // 5. CONFIRMATION DIALOG
            // ================================
            DialogResult result = MessageBox.Show(
                summary,
                EditingScheduleID.HasValue ? "Confirm Schedule Update" : "Confirm Schedule Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                MessageBox.Show("Action cancelled.");
                return;
            }

            // ================================
            // 6. DATABASE INSERT / UPDATE
            // ================================
            try
            {
                if (EditingScheduleID.HasValue)
                {
                    // UPDATE existing schedule
                    bool ok = db.UpdateSchedule(
                        EditingScheduleID.Value,
                        ferryID,
                        routeID,
                        departure.TimeOfDay,
                        arrival.TimeOfDay,
                        operatingDays,
                        startDate,
                        endDate,
                        isActive
                    );

                    if (ok)
                    {
                        // Also update trip timings to keep them in sync
                        db.UpdateTripsTimes(EditingScheduleID.Value, departure.TimeOfDay, arrival.TimeOfDay);

                        MessageBox.Show("Schedule updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Insert new schedule (existing behavior)
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

                    // Generate Trips based on schedule
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

                    // Insert Floor Prices for each Trip
                    foreach (int tripID in tripIDs)
                    {
                        foreach (var fp in floorPrices)
                        {
                            db.InsertTripFloorPrice(tripID, ferryID, fp.Key, fp.Value);
                        }
                    }

                    MessageBox.Show($"✅ Schedule created successfully!\nGenerated {tripIDs.Count} trip(s).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add this helper method to show conflict details in a dialog
        private void ShowConflictDetailsDialog(DataTable conflictDetails)
        {
            Form detailsForm = new Form
            {
                Text = "Conflict Details",
                Width = 800,
                Height = 500,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = conflictDetails,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Customize column headers
            if (dgv.Columns.Contains("TripID"))
                dgv.Columns["TripID"].HeaderText = "Trip ID";
            if (dgv.Columns.Contains("TripDate"))
                dgv.Columns["TripDate"].HeaderText = "Date";
            if (dgv.Columns.Contains("DepartureTime"))
                dgv.Columns["DepartureTime"].HeaderText = "Departure";
            if (dgv.Columns.Contains("ArrivalTime"))
                dgv.Columns["ArrivalTime"].HeaderText = "Arrival";
            if (dgv.Columns.Contains("ConflictType"))
                dgv.Columns["ConflictType"].HeaderText = "Conflict Type";

            Button closeButton = new Button
            {
                Text = "Close",
                Width = 100,
                Height = 35,
                Dock = DockStyle.Bottom
            };
            closeButton.Click += (s, e) => detailsForm.Close();

            detailsForm.Controls.Add(dgv);
            detailsForm.Controls.Add(closeButton);

            detailsForm.ShowDialog(this);
        }
    }
}
