using Microsoft.VisualBasic.ApplicationServices;
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

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class Schedules : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OwnerID { get; set; }
        
        public Schedules(int ownerID)
        {
            InitializeComponent();
            OwnerID = ownerID;
            LoadSchedule(OwnerID);
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            Dialogs.AddSchedule addOwnerDialog = new Dialogs.AddSchedule(OwnerID);
            addOwnerDialog.StartPosition = FormStartPosition.CenterParent;
            addOwnerDialog.ShowDialog();
        }

        private void LoadSchedule(int OwnerID)
        {
            try
            {
                DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();
                // 1. Get data from the view (now with corrected price info)
                string query = "SELECT * FROM vw_TripScheduleWithPrices WHERE OwnerID = @OwnerID;";

                SqlParameter[] parameters = { new SqlParameter("@OwnerID", OwnerID) };

                DataTable dt = db.ExecuteDataTable(query, parameters);

                // DEBUG: Show what columns we actually got from the database
                #if DEBUG
                var columnNames = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                System.Diagnostics.Debug.WriteLine($"Columns returned from vw_TripScheduleWithPrices: {columnNames}");
                #endif

                // 2. Bind to DataGridView
                dgvSchedule.DataSource = dt;

                // 3. Set column headers (optional, for readability)
                if (dgvSchedule.Columns.Contains("FerryName"))
                    dgvSchedule.Columns["FerryName"].HeaderText = "Ferry";
                if (dgvSchedule.Columns.Contains("Route"))
                    dgvSchedule.Columns["Route"].HeaderText = "Route";
                if (dgvSchedule.Columns.Contains("DepartureTime"))
                    dgvSchedule.Columns["DepartureTime"].HeaderText = "Departure";
                if (dgvSchedule.Columns.Contains("ArrivalTime"))
                    dgvSchedule.Columns["ArrivalTime"].HeaderText = "Arrival";
                if (dgvSchedule.Columns.Contains("DaysOfWeek"))
                    dgvSchedule.Columns["DaysOfWeek"].HeaderText = "Days";
                if (dgvSchedule.Columns.Contains("StartDate"))
                    dgvSchedule.Columns["StartDate"].HeaderText = "Start Date";
                if (dgvSchedule.Columns.Contains("EndDate"))
                    dgvSchedule.Columns["EndDate"].HeaderText = "End Date";
                if (dgvSchedule.Columns.Contains("Price"))
                    dgvSchedule.Columns["Price"].HeaderText = "Price";

                if (dgvSchedule.Columns.Contains("DaysOfWeek"))
                {
                    dgvSchedule.Columns["DaysOfWeek"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                dgvSchedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvSchedule.CellFormatting -= dgvSchedule_CellFormatting;
                dgvSchedule.CellFormatting += dgvSchedule_CellFormatting;

                // Hide internal key columns but DON'T remove them - we need them for the click event
                if (dgvSchedule.Columns.Contains("OwnerID"))
                    dgvSchedule.Columns["OwnerID"].Visible = false;
                if (dgvSchedule.Columns.Contains("ScheduleID"))
                    dgvSchedule.Columns["ScheduleID"].Visible = false;
                if (dgvSchedule.Columns.Contains("FerryID"))
                    dgvSchedule.Columns["FerryID"].Visible = false;
                if (dgvSchedule.Columns.Contains("RouteID"))
                    dgvSchedule.Columns["RouteID"].Visible = false;
                if (dgvSchedule.Columns.Contains("IsActive"))
                    dgvSchedule.Columns["IsActive"].Visible = false;

                // 4. Make Price column multi-line
                if (dgvSchedule.Columns.Contains("Price"))
                    dgvSchedule.Columns["Price"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // 5. Auto-size columns for better readability
                dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 6. Adjust row height (increase if more floors exist)
                dgvSchedule.RowTemplate.Height = 50;

                // 7. Optional: prevent user from editing
                dgvSchedule.ReadOnly = true;

                // 8. Use single "Actions" column and paint three buttons like dgvMyFerries
                if (!dgvSchedule.Columns.Contains("Actions"))
                {
                    var act = new DataGridViewButtonColumn
                    {
                        Name = "Actions",
                        HeaderText = "Actions",
                        Text = "⋯",
                        UseColumnTextForButtonValue = false,
                        FlatStyle = FlatStyle.Flat,
                        DefaultCellStyle = { ForeColor = Color.White, BackColor = Color.FromArgb(0, 123, 255) }
                    };
                    dgvSchedule.Columns.Add(act);
                }

                // subscribe event handlers
                dgvSchedule.CellPainting -= dgvSchedule_CellPainting;
                dgvSchedule.CellPainting += dgvSchedule_CellPainting;
                dgvSchedule.CellClick -= dgvSchedule_CellClick;
                dgvSchedule.CellClick += dgvSchedule_CellClick;
                dgvSchedule.CellMouseEnter -= dgvSchedule_CellMouseEnter;
                dgvSchedule.CellMouseEnter += dgvSchedule_CellMouseEnter;

                if (dt.Rows.Count == 0)
                {
                    lblEmptyMessage.Visible = true;
                    lblEmptyMessage.Text = "No Schedule available";
                    dgvSchedule.Visible = false;
                }
                else
                {
                    lblEmptyMessage.Visible = false;
                    dgvSchedule.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }
        
        private void dgvSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSchedule.Columns[e.ColumnIndex].Name == "DepartureTime" ||
                dgvSchedule.Columns[e.ColumnIndex].Name == "ArrivalTime")
            {
                if (e.Value is TimeSpan ts)
                {
                    // Format TimeSpan as 9:00 AM
                    DateTime dt = DateTime.Today.Add(ts);
                    e.Value = dt.ToString("h:mm tt");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvSchedule_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvSchedule.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Load your icons (make sure you have them in Resources or as files)
                Image viewIcon = Properties.Resources.research;    // Eye icon for View
                Image editIcon = Properties.Resources.edit; // Pencil icon for Edit
                Image deleteIcon = Properties.Resources.delete; // Trash icon for Delete

                int iconSize = 35;
                int padding = 5;
                int totalWidth = (iconSize * 3) + (padding * 2);

                // calculate starting X to center the block
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;

                // vertical center
                int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                // Draw icons spaced horizontally
                e.Graphics.DrawImage(viewIcon, startX, y, iconSize, iconSize);
                e.Graphics.DrawImage(editIcon, startX + iconSize + padding, y, iconSize, iconSize);
                e.Graphics.DrawImage(deleteIcon, startX + (iconSize + padding) * 2, y, iconSize, iconSize);

                e.Handled = true;
            }
        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSchedule.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cell = dgvSchedule.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int clickX = dgvSchedule.PointToClient(Cursor.Position).X - cell.X;
                int iconSize = 35;
                int padding = 5;

                try
                {
                    // Check which required columns are missing
                    List<string> missingColumns = new List<string>();
                    string[] requiredColumns = { "ScheduleID", "FerryID", "StartDate", "EndDate", "DaysOfWeek" };
                    
                    foreach (string colName in requiredColumns)
                    {
                        if (!dgvSchedule.Columns.Contains(colName))
                        {
                            missingColumns.Add(colName);
                        }
                    }

                    if (missingColumns.Count > 0)
                    {
                        string availableCols = string.Join(", ", 
                            dgvSchedule.Columns.Cast<DataGridViewColumn>().Select(c => c.Name));
                        
                        MessageBox.Show(
                            $"Missing columns: {string.Join(", ", missingColumns)}\n\n" +
                            $"Available columns: {availableCols}\n\n" +
                            "Please update the vw_TripScheduleWithPrices view to include all required columns.", 
                            "Error - Missing Columns", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }

                    int scheduleID = Convert.ToInt32(dgvSchedule.Rows[e.RowIndex].Cells["ScheduleID"].Value);
                    int ferryID = Convert.ToInt32(dgvSchedule.Rows[e.RowIndex].Cells["FerryID"].Value);
                    DateTime startDate = Convert.ToDateTime(dgvSchedule.Rows[e.RowIndex].Cells["StartDate"].Value);
                    DateTime endDate = Convert.ToDateTime(dgvSchedule.Rows[e.RowIndex].Cells["EndDate"].Value);
                    string daysOfWeek = dgvSchedule.Rows[e.RowIndex].Cells["DaysOfWeek"].Value?.ToString() ?? "";

                    if (clickX < padding + iconSize) // View/Research icon clicked
                    {
                        // Open ScheduleViewDialog with calendar
                        var viewDialog = new Dialogs.ScheduleViewDialog(scheduleID, ferryID, startDate, endDate, daysOfWeek);
                        viewDialog.ShowDialog();
                        
                        // Refresh the schedule grid after viewing
                        LoadSchedule(OwnerID);
                    }
                    else if (clickX < padding + iconSize + padding + iconSize) // Edit icon clicked
                    {
                        // Check if schedule has bookings
                        DATABASE.FerryOwnerHelper ownerHelper = new DATABASE.FerryOwnerHelper();
                        var (hasBookings, futureBookings, totalBookings) = ownerHelper.CheckScheduleBookings(scheduleID);

                        if (hasBookings)
                        {
                            string message = futureBookings > 0
                                ? $"Cannot edit this schedule.\n\n" +
                                  $"Active Bookings: {futureBookings}\n" +
                                  $"Total Bookings: {totalBookings}\n\n" +
                                  $"Schedules with active bookings cannot be modified to protect passenger reservations."
                                : $"Cannot edit this schedule.\n\n" +
                                  $"This schedule has {totalBookings} booking(s) in history.\n" +
                                  $"Schedules with booking history cannot be modified to maintain data integrity.";

                            MessageBox.Show(message, "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // No bookings - allow edit
                        var editDialog = new Dialogs.AddSchedule(OwnerID, scheduleID);
                        editDialog.StartPosition = FormStartPosition.CenterParent;
                        if (editDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh the schedule grid after successful edit
                            LoadSchedule(OwnerID);
                        }
                    }
                    else // Delete icon clicked
                    {
                        // Use the enhanced validation system from FerryOwnerHelper
                        DATABASE.FerryOwnerHelper ownerHelper = new DATABASE.FerryOwnerHelper();
                        var validation = ownerHelper.ValidateScheduleDeletion(scheduleID);

                        if (!validation.CanProceed)
                        {
                            MessageBox.Show(validation.Message, "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Show confirmation with appropriate message based on delete type
                        string confirmMessage = validation.DeleteType == DATABASE.DeleteType.Soft
                            ? $"This schedule will be marked as INACTIVE (not permanently deleted).\n\n{validation.Message}\n\nContinue?"
                            : $"This schedule will be PERMANENTLY DELETED.\n\n{validation.Message}\n\nContinue?";

                        DialogResult result = MessageBox.Show(
                            confirmMessage,
                            "Confirm Delete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            string error;
                            bool success = ownerHelper.DeleteScheduleEnhanced(scheduleID, out error);

                            if (success)
                            {
                                MessageBox.Show(
                                    validation.DeleteType == DATABASE.DeleteType.Soft 
                                        ? "Schedule has been deactivated successfully." 
                                        : "Schedule deleted successfully.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                LoadSchedule(OwnerID);
                            }
                            else
                            {
                                MessageBox.Show($"Error deleting schedule: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error accessing schedule data: {ex.Message}\n\n" +
                        $"Stack trace: {ex.StackTrace}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvSchedule_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvSchedule.Columns.Contains("Actions"))
            {
                dgvSchedule.Cursor = Cursors.Default;
                return;
            }

            if (e.ColumnIndex == dgvSchedule.Columns["Actions"].Index && e.RowIndex >= 0)
                dgvSchedule.Cursor = Cursors.Hand;
            else
                dgvSchedule.Cursor = Cursors.Default;
        }
    }
}
