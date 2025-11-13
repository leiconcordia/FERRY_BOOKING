using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class Schedules : UserControl
    {
        public int OwnerID { get; set; }
        public Schedules(int ownerID)
        {
            InitializeComponent();
            OwnerID = ownerID;
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            Dialogs.AddSchedule addOwnerDialog = new Dialogs.AddSchedule(OwnerID);
            addOwnerDialog.StartPosition = FormStartPosition.CenterParent;
            addOwnerDialog.ShowDialog();
        }


    }
}
