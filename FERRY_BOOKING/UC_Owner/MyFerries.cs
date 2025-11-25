using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class MyFerries : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserEmail { get; set; }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CompanyName { get; set; }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OwnerID { get; set; }
        
        public MyFerries(int OwnerID, string Email, string CompanyName)
        {
          

            InitializeComponent();
            LoadMyFerries(OwnerID);
            lblCompanyNameFleet.Text = $"{CompanyName} - Ferry Fleet";

            this.UserEmail = Email;
            this.CompanyName = CompanyName;
            this.OwnerID = OwnerID;

        }


             

        private void btnRegisterFerry_Click(object sender, EventArgs e)
        {
            FerryRegistrationForm popup = new FerryRegistrationForm(OwnerID, CompanyName);
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                LoadMyFerries(OwnerID);
            }


        }



        public void LoadMyFerries(int ownerID)
        {
            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

            string query = "SELECT FerryID, FerryCode, FerryName, Status, Capacity, Seats " +
                           "FROM vw_FerryDisplay WHERE OwnerID = @OwnerID";

            SqlParameter[] parameters = { new SqlParameter("@OwnerID", ownerID) };

            DataTable dt = db.ExecuteDataTable(query, parameters);
            dgvMyFerries.DataSource = dt;

            dgvMyFerries.Columns["FerryID"].Visible = false;
            dgvMyFerries.Columns["Seats"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            /* ======  NEW : single Actions column  ====== */
            if (!dgvMyFerries.Columns.Contains("Actions"))
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
                dgvMyFerries.Columns.Add(act);
            }
            if (dt.Rows.Count == 0)
            {
                lblEmptyMessage.Visible = true;
                lblEmptyMessage.Text = "No Ferries available";
                dgvMyFerries.Visible = false;
            }
            else
            {
                lblEmptyMessage.Visible = false;
                dgvMyFerries.Visible = true;
                dgvMyFerries.DataSource = dt;
            }

        }

        private void dgvMyFerries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvMyFerries.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Load your icons (make sure you have them in Resources or as files)
                Image viewIcon = Properties.Resources.research;    // Eye icon for View
                Image editIcon = Properties.Resources.edit; // Pencil icon for Edit
                Image deleteIcon = Properties.Resources.delete; // Trash icon for Delete

                int iconSize = 35;
                int padding = 10;
                // total width of icons + gaps
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



        private void dgvMyFerries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMyFerries.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int w = dgvMyFerries.Columns[e.ColumnIndex].Width / 3;
                int x = dgvMyFerries.PointToClient(Cursor.Position).X -
                        dgvMyFerries.GetColumnDisplayRectangle(e.ColumnIndex, true).X;

                int ferryID = Convert.ToInt32(dgvMyFerries.Rows[e.RowIndex].Cells["FerryID"].Value);
                string ferryName = dgvMyFerries.Rows[e.RowIndex].Cells["FerryName"].Value.ToString();
                if (x < w)      // VIEW
                {
                    var viewDialog = new FerryViewDialog(ferryID);
                    viewDialog.StartPosition = FormStartPosition.CenterParent;
                    viewDialog.ShowDialog();
                }
                else if (x < w * 2) // EDIT
                {
                    var editForm = new FerryRegistrationForm(ferryID, this.OwnerID, this.CompanyName, editMode: true);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    if (editForm.ShowDialog() == DialogResult.OK)
                        LoadMyFerries(OwnerID);
                }
                else                // DELETE
                {
                    if (MessageBox.Show($"Delete ferry {ferryName} ?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FerryOwnerHelper helper = new FerryOwnerHelper();
                        string error;

                        bool deleted = helper.DeleteFerry(ferryID, out error);

                        if (deleted)
                        {
                            MessageBox.Show("Ferry deleted.");
                            LoadMyFerries(OwnerID);
                        }
                        else
                        {
                            MessageBox.Show(error, "Delete blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
            }
        }

        private void dgvMyFerries_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMyFerries.Columns["Actions"].Index && e.RowIndex >= 0)
                dgvMyFerries.Cursor = Cursors.Hand;
            else
                dgvMyFerries.Cursor = Cursors.Default;
        }

    }
}
