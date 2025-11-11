using FERRY_BOOKING.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public MyFerries(string Email, string CompanyName)
        {
            DATABASE.FerryOwnerHelper od = new DATABASE.FerryOwnerHelper();

            InitializeComponent();
            LoadMyFerries();
            lblCompanyNameFleet.Text = $"{CompanyName} - Ferry Fleet";

            this.UserEmail = Email;
            this.CompanyName = CompanyName;
            OwnerID = od.GetUserIDByEmail(UserEmail);
            

        }


             

        private void btnRegisterFerry_Click(object sender, EventArgs e)
        {
            FerryRegistrationForm popup = new FerryRegistrationForm(OwnerID, CompanyName);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }

        public void LoadMyFerries()
        {
            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();         
            string query = "SELECT FerryID, FerryCode, FerryName, Status, Capacity, Seats, Status, Route FROM vw_FerryDisplay";

            DataTable dt = db.ExecuteDataTable(query);
            dgvMyFerries.DataSource = dt;

            // Hide FerryID
            dgvMyFerries.Columns["FerryID"].Visible = false;

            // Seats column wrap text
            dgvMyFerries.Columns["Seats"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

       



    }
}
