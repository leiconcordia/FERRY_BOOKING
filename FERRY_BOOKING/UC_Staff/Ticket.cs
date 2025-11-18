using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FERRY_BOOKING.Dialogs;   // << where TicketData lives
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class Ticket : UserControl
    {
        public Ticket() => InitializeComponent();

        /* call this from TicketForm after you create the UC */
        public void SetData(TicketData data)
        {
            lblBookingRef.Text = data.BookingRef;
            lblCompanyName.Text = data.Company;
            lblFerry.Text = data.Ferry;
            lblOrigin.Text = data.Origin;
            lblDestination.Text = data.Destination;
            lblDeparture.Text = data.Departure;
            lblArrival.Text = data.Arrival;
            lblSeat.Text = data.Seat;
            lblPassengerName.Text = data.Name;
            lblDate.Text = data.TripDate;
            lblPrice.Text = data.Price.ToString("C", new CultureInfo("fil-PH"));

            
            lbl2PassengerName.Text = data.Name;
            lbl2Ferry.Text = data.Ferry;
            lbl2BookingRef.Text = data.BookingRef;
            lbl2CompanyName.Text = data.Company;
            lbl2Departure.Text = data.TripDate;
            lbl2Origin.Text = data.Origin;
            lbl2Destination.Text = data.Destination;
            lbl2Seat.Text = data.Seat;
        }
    }
}
