using FERRY_BOOKING.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class PassengerInfoControl : UserControl
    {

        public string PassengerName => tbFullName.Text;
        public int PassengerAge => (int)nudAge.Value;

        public string PassengerGender => cmbGender.SelectedItem?.ToString();
        public string PassengerDiscount => cmbDiscount.SelectedItem?.ToString();
        public byte[] IDImage { get; private set; }   // raw file

        public Image IDImageBytes => IDImage == null ? null
                                  : Image.FromStream(new MemoryStream(IDImage));// raw JPG/PNG bytes
        public string DiscountType => cmbDiscount.SelectedItem?.ToString();

        public decimal Price { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SeatCode { get; set; }

        public event Action PriceChanged;
        public PassengerInfoControl(string seatCode, decimal SeatPrice)
        {

          


        InitializeComponent();
            SeatCode = seatCode;
            Price = SeatPrice;
            string labelPrice = Price.ToString("C", new CultureInfo("fil-PH"));
            lblSeat.Text = $"Seat: {seatCode}";


            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbDiscount.Items.AddRange(new string[] { "None", "Senior", "Student", "PWD" });

            btnUploadID.Visible = false; // hide at start
            lblFileName.Visible = false;
            cmbDiscount.SelectedIndexChanged += CmbDiscount_SelectedIndexChanged;

            lblPrice.Text = $"Price: {labelPrice}";
        }

     

        private void CmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show upload button only if discounted
            btnUploadID.Visible = cmbDiscount.SelectedItem.ToString() != "None";
            lblFileName.Visible = cmbDiscount.SelectedItem.ToString() != "None";    
        }

        private void btnUploadID_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Title = "Select ID picture";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    IDImage = File.ReadAllBytes(dlg.FileName);
                    lblFileName.Text = $"✓ {Path.GetFileName(dlg.FileName)}";
                    btnUploadID.Text = "Change ID";

                    // 20 % discount on any discount type
                    ApplyDiscount();
                    
                }
            }
        }

        private void ApplyDiscount()
        {
            if (IDImage == null || IDImage.Length == 0) return;   // safety

            Price *= 0.80m;                     // 20 % off
            lblPrice.Text = $"Price: {Price.ToString("C", new CultureInfo("fil-PH"))}";

            PriceChanged?.Invoke();
        }
    }

}
