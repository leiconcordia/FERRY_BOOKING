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
        private bool hasUserTouchedDates = false; // Track if user has interacted with date pickers
        private bool hasUserTouchedDepartureTime = false; // Track if user has interacted with departure time

        public AddSchedule(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;

            LoadFerriesDropdown();
            InitializeDayButtons();
            DisableAllControlsExceptFerry(); // Step 1: Only ferry selection enabled
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
            // Enable all controls for edit mode
            EnableAllControls();
            hasUserTouchedDates = true;
            hasUserTouchedDepartureTime = true;

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
                dtpArrivalTime.Enabled = false; // Keep arrival time readonly
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

        private void DisableAllControlsExceptFerry()
        {
            // Disable route selection until ferry is selected
            cbRoute.Enabled = false;

            // Disable dates until route is selected
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;

            // Disable times until route is selected
            dtpDepartureTime.Enabled = false;
            dtpArrivalTime.Enabled = false;

            // Disable status until route is selected
            cbStatus.Enabled = false;

            // Disable day buttons
            DisableAllDayButtons();
            btnSelectAll.Enabled = false;

       

            // Disable save button
            btnAddSchedule.Enabled = false;
        }

        private void EnableAllControls()
        {
            cbRoute.Enabled = true;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            dtpDepartureTime.Enabled = true;
            cbStatus.Enabled = true;
            btnSelectAll.Enabled = true;
            
            btnAddSchedule.Enabled = true;
        }

        private void DisableAllDayButtons()
        {
            Button[] dayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };
            foreach (Button btn in dayButtons)
            {
                btn.Enabled = false;
                btn.BackColor = Color.DarkGray;
                btn.FlatAppearance.BorderColor = Color.DarkGray;
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

        private void cbFerry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFerry.SelectedItem == null)
            {
                DisableAllControlsExceptFerry();
                return;
            }

            DataRowView drv = cbFerry.SelectedItem as DataRowView;
            if (drv == null) return;

            int ferryID = Convert.ToInt32(drv["FerryID"]);

            // Load routes & floors
            LoadRoutesForFerry(ferryID);
            LoadFloors(ferryID);

            // Enable route selection (Step 2)
            cbRoute.Enabled = true;

            
        }

        

        private void cbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoute.SelectedItem == null)
            {
                // Keep route and above enabled, but disable everything else
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                dtpDepartureTime.Enabled = false;
                dtpArrivalTime.Enabled = false;
                cbStatus.Enabled = false;
                DisableAllDayButtons();
                btnSelectAll.Enabled = false;
                btnAddSchedule.Enabled = false;
                return;
            }

            DataRowView drv = cbRoute.SelectedItem as DataRowView;
            if (drv == null) return;

            int routeID = Convert.ToInt32(drv["RouteID"]);

            // Enable remaining controls (Step 3)
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            dtpDepartureTime.Enabled = true;
            cbStatus.Enabled = true;
            btnAddSchedule.Enabled = true;

            // Update day buttons based on current date range
            if (hasUserTouchedDates)
            {
                UpdateDayButtonsForDateRange(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
            }
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
            // Mark that user has touched the departure time
            hasUserTouchedDepartureTime = true;

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

            // Auto-calculate arrival time and make it readonly
            dtpArrivalTime.Value = dtpDepartureTime.Value.Add(duration);
            dtpArrivalTime.Enabled = false;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Mark that user has touched the dates
            hasUserTouchedDates = true;

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateDayButtonsForDateRange(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            // Mark that user has touched the dates
            hasUserTouchedDates = true;

            // Ensure end date >= start date
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be before start date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Enable Select All button only if at least one day is enabled
            btnSelectAll.Enabled = dayButtons.Any(btn => btn.Enabled);

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
            
            // Only check enabled buttons
            var enabledButtons = allDayButtons.Where(btn => btn.Enabled).ToArray();
            
            if (enabledButtons.Length == 0)
            {
                btnSelectAll.Text = "Select All";
                return;
            }

            bool allSelected = enabledButtons.All(btn => btn.BackColor == Color.White);
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
                if (btn.Enabled)
                {
                    btn.BackColor = Color.LightGray;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                }
            }
        }

        // Initialize the buttons (call this in form load)
        private void InitializeDayButtons()
        {
            // Set initial button properties
            Button[] dayButtons = { btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun };

            foreach (Button btn in dayButtons)
            {
                btn.BackColor = Color.DarkGray;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.DarkGray;
                btn.Enabled = false;
            }

            // Set Select All button
            btnSelectAll.Text = "Select All";
            btnSelectAll.Enabled = false;
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

            var check = db.CheckTripConflicts(
                ferryID,
                routeID,
                startDate,
                endDate,
                operatingDays,
                departure,
                arrival
            );

            if (check.hasConflict)
            {
                MessageBox.Show(check.message, "🚫 Port Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Optional: Show the grid of who is blocking you
                // DataGridViewConflict.DataSource = check.details; 

                return; // Stop right here! Don't save.
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
