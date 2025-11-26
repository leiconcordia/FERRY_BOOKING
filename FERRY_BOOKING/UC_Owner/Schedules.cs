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

                // 8. Use single "Actions" column with only View and Delete buttons
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

                // Load only View and Delete icons (Edit removed)
                Image viewIcon = Properties.Resources.research;    // Eye icon for View
                Image deleteIcon = Properties.Resources.delete; // Trash icon for Delete

                int iconSize = 35;
                int padding = 10; // Increased padding for better spacing with 2 icons
                int totalWidth = (iconSize * 2) + padding;

                // calculate starting X to center the block
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;

                // vertical center
                int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                // Draw only View and Delete icons
                e.Graphics.DrawImage(viewIcon, startX, y, iconSize, iconSize);
                e.Graphics.DrawImage(deleteIcon, startX + iconSize + padding, y, iconSize, iconSize);

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
                int padding = 10; // Updated padding to match CellPainting

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

                    if (clickX < iconSize + (padding / 2)) // View icon clicked
                    {
                        // Open ScheduleViewDialog with calendar
                        var viewDialog = new Dialogs.ScheduleViewDialog(scheduleID, ferryID, startDate, endDate, daysOfWeek);
                        viewDialog.ShowDialog();
                        
                        // Refresh the schedule grid after viewing
                        LoadSchedule(OwnerID);
                    }
                    else // Delete icon clicked
                    {
                        // Use the enhanced validation system from FerryOwnerHelper
                        DATABASE.FerryOwnerHelper ownerHelper = new DATABASE.FerryOwnerHelper();
                        var validation = ownerHelper.ValidateScheduleDeletion(scheduleID);

                        // Check if deletion is blocked due to bookings
                        if (!validation.CanProceed)
                        {
                            // Show error message with detailed information
                            MessageBox.Show(
                                validation.Message,
                                "⚠️ Cannot Delete Schedule",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        // Check if it's a soft delete (has booking history)
                        if (validation.DeleteType == DATABASE.DeleteType.Soft)
                        {
                            // Show warning that schedule has bookings and cannot be deleted
                            MessageBox.Show(
                                $"❌ CANNOT DELETE SCHEDULE\n\n" +
                                $"This schedule has {validation.AffectedRecords} booking(s) in the system.\n\n" +
                                $"⚠️ Schedules with active or historical bookings cannot be deleted to preserve booking records and maintain data integrity.\n\n" +
                                $"📋 What you can do:\n" +
                                $"• Wait for all future trips to complete\n" +
                                $"• Contact administrator for data archival\n" +
                                $"• Create a new schedule instead",
                                "Cannot Delete - Active Bookings",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return;
                        }

                        // Only proceed if it's a hard delete (no bookings)
                        if (validation.DeleteType == DATABASE.DeleteType.Hard)
                        {
                            string confirmMessage = 
                                "⚠️ PERMANENT DELETE WARNING\n\n" +
                                "This schedule and all associated trips will be PERMANENTLY DELETED.\n\n" +
                                "This action cannot be undone.\n\n" +
                                "Do you want to continue?";

                            DialogResult result = MessageBox.Show(
                                confirmMessage,
                                "Confirm Permanent Deletion",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                            );

                            if (result == DialogResult.Yes)
                            {
                                string error;
                                bool success = ownerHelper.DeleteScheduleEnhanced(scheduleID, out error);

                                if (success)
                                {
                                    MessageBox.Show(
                                        "✅ Schedule and all associated trips have been permanently deleted.",
                                        "Delete Successful",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );
                                    LoadSchedule(OwnerID);
                                }
                                else
                                {
                                    MessageBox.Show(
                                        $"❌ Error deleting schedule:\n\n{error}",
                                        "Delete Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error accessing schedule data:\n\n{ex.Message}\n\n" +
                        $"Stack trace: {ex.StackTrace}", 
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );
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
