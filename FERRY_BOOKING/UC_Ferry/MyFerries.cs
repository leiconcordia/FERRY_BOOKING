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

        public void LoadMyFerries(int ownerID)
        {
            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

            string query = "SELECT FerryID, FerryCode, FerryName, Status, Capacity, Seats, Route " +
                           "FROM vw_FerryDisplay WHERE OwnerID = @OwnerID";

            SqlParameter[] parameters =
            {
        new SqlParameter("@OwnerID", ownerID)
    };

            DataTable dt = db.ExecuteDataTable(query, parameters);
            

            dgvMyFerries.DataSource = dt;
            dgvMyFerries.Columns["FerryID"].Visible = false;
            dgvMyFerries.Columns["Seats"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }






    }
}
