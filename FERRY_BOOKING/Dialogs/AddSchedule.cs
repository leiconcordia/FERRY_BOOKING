using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
    }
}
