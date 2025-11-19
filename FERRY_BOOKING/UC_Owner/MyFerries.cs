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

        public string UserEmail { get; set; }
        public string CompanyName { get; set; }
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
            popup.ShowDialog();

           
        }

        //    public void LoadMyFerries(int ownerID)
        //    {
        //        DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

        //        string query = "SELECT FerryID, FerryCode, FerryName, Status, Capacity, Seats, Route " +
        //                       "FROM vw_FerryDisplay WHERE OwnerID = @OwnerID";

        //        SqlParameter[] parameters =
        //        {
        //          new SqlParameter("@OwnerID", ownerID)
        //};

        //        DataTable dt = db.ExecuteDataTable(query, parameters);


        //        dgvMyFerries.DataSource = dt;
        //        dgvMyFerries.Columns["FerryID"].Visible = false;
        //        dgvMyFerries.Columns["Seats"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    }

        public void LoadMyFerries(int ownerID)
        {
            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

            string query = "SELECT FerryID, FerryCode, FerryName, Status, Capacity, Seats, Route " +
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


        }

        private void dgvMyFerries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvMyFerries.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                /* ==========  FIXED BUTTON SIZE  ========== */
                const int BTN_W = 60;   // px
                const int BTN_H = 33;   // px
                const int GAP = 4;    // small gap between buttons

                int left = e.CellBounds.X + (e.CellBounds.Width - (BTN_W * 3 + GAP * 2)) / 2; // centre group
                int top = e.CellBounds.Y + (e.CellBounds.Height - BTN_H) / 2;                  // centre vertically

                Rectangle viewR = new Rectangle(left, top, BTN_W, BTN_H);
                Rectangle editR = new Rectangle(left + BTN_W + GAP, top, BTN_W, BTN_H);
                Rectangle delR = new Rectangle(left + (BTN_W + GAP) * 2, top, BTN_W, BTN_H);

                Color grey = Color.FromArgb(112, 112, 112);
                Color blue = Color.FromArgb(0, 123, 255);
                Color red = Color.FromArgb(220, 53, 69);

                using (SolidBrush brush = new SolidBrush(grey)) e.Graphics.FillRectangle(brush, viewR);
                using (SolidBrush brush = new SolidBrush(blue)) e.Graphics.FillRectangle(brush, editR);
                using (SolidBrush brush = new SolidBrush(red)) e.Graphics.FillRectangle(brush, delR);

                TextRenderer.DrawText(e.Graphics, "View", e.CellStyle.Font, viewR, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                TextRenderer.DrawText(e.Graphics, "Edit", e.CellStyle.Font, editR, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                TextRenderer.DrawText(e.Graphics, "Delete", e.CellStyle.Font, delR, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

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
                    MessageBox.Show($"VIEW ferry {ferryName} (ID {ferryID})", "View clicked");
                else if (x < w * 2) // EDIT
                    MessageBox.Show($"EDIT ferry {ferryName} (ID {ferryID})", "Edit clicked");
                else                // DELETE
                {
                    if (MessageBox.Show($"Delete ferry {ferryName} ?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        MessageBox.Show($"DELETE ferry {ferryName} (ID {ferryID}) – wire real delete later.", "Delete clicked");
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
