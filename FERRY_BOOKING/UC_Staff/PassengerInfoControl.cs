using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class PassengerInfoControl : UserControl
    {
        public string SeatCode { get; set; }

        public PassengerInfoControl(string seatCode)
        {
            InitializeComponent();
            SeatCode = seatCode;
            lblSeat.Text = $"Seat: {seatCode}";
            

            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbDiscount.Items.AddRange(new string[] { "None", "Senior", "Student", "PWD" });

            btnUploadID.Visible = false; // hide at start
            cmbDiscount.SelectedIndexChanged += CmbDiscount_SelectedIndexChanged;
        }

        private void CmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show upload button only if discounted
            btnUploadID.Visible = cmbDiscount.SelectedItem.ToString() != "None";
        }
    }

}
