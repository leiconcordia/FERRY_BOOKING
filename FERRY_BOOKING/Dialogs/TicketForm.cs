using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.UC_Staff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static FERRY_BOOKING.Dialogs.BookingForm; // Add this line to import TicketData

namespace FERRY_BOOKING.Dialogs
{
    public partial class TicketForm : Form
    {
        private readonly List<TicketData> _tickets; // Change type to TicketData
        private readonly PrintDocument _pd;
        private readonly string _bookingRef;

        public TicketForm(List<TicketData> tickets, string BookingRef) // Change parameter type to TicketData
        {
            InitializeComponent();
            _tickets = tickets;
            _bookingRef = BookingRef;
            _pd = new PrintDocument();
            _pd.PrintPage += OnPrintPage;

            LoadTickets();
        }

        /* ---- create one UserControl ticket per passenger ---- */
        private void LoadTickets()
        {
            flpTicket.Controls.Clear();
            foreach (var t in _tickets)
            {
                var uc = new Ticket();   // your UserControl
                uc.SetData(t);           // fills labels inside UC
                flpTicket.Controls.Add(uc);
            }
        }

        /* ---- PRINT button you dropped on the form ---- */
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentTicket = 0;

            // 1. create a NEW document for band paper
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Band", 315, 400); // 8 cm ≈ 315 px
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pd.PrintPage += OnPrintPage;

            // NEW: notify when finished
            pd.EndPrint += (s, args) =>
            // user cancelled – do nothing
                SaveBookingToDatabase();
                MessageBox.Show("All tickets have been printed successfully.",
                               "Print Complete",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

            
             

            PrintDialog dlg = new PrintDialog { Document = pd };
            if (dlg.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        /* ---- print one ticket per page ---- */

        private int _currentTicket = 0;   // field at top of TicketForm

        private void OnPrintPage(object sender, PrintPageEventArgs e)
    {
        // 8 cm wide, height = sum of all ticket controls
        int width  = 806;                      // 8 cm in pixels @ 96 dpi
        int height = flpTicket.Controls.Cast<Control>().Sum(c => c.Height);

        Bitmap strip = new Bitmap(width, height);
        Graphics g   = Graphics.FromImage(strip);

        int y = 0;
        foreach (Ticket uc in flpTicket.Controls)
        {
            uc.DrawToBitmap(strip, new Rectangle(0, y, width, uc.Height));
            y += uc.Height;
        }

        e.Graphics.DrawImage(strip, 0, 0);
        e.HasMorePages = false;   // one continuous strip
    }




        private void SaveBookingToDatabase()
        {
            var dal = new StaffHelper();

            long bookingID = dal.SaveBookingHeader(_bookingRef,
                                                  _tickets[0].TripID,
                                                  _tickets.Sum(t => t.Price));

            foreach (var t in _tickets)
            {
                // Convert Image to byte[] before passing to SavePassenger
                byte[] idImageBytes = null;
                if (t.IDImage != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        t.IDImage.Save(ms, t.IDImage.RawFormat);
                        idImageBytes = ms.ToArray();
                    }
                }

                dal.SavePassenger(bookingID, t.Seat, t.Name, t.Age,
                                  t.Gender, t.Discount, t.Price,
                                  idImageBytes);

                dal.InsertBookedSeat(t.TripID, t.FerryID, t.Seat);
            }

            MessageBox.Show($"Booking {_bookingRef} saved.",
                            "Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}