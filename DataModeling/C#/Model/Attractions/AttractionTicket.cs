using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class AttractionTicket : IReservation
    {
        public int ReservationID { get; }

        public int AttractionID { get; }

        public DateTime TicketDate { get; }

        public double Price { get; }

        public AttractionTicket(int reservationID, int attractionID, DateTime ticketDate, double price)
        {
            ReservationID = reservationID;
            AttractionID = attractionID;
            TicketDate = ticketDate;
            Price = price;
        }
        public override string ToString()
        {
            return $"ReservationID: {ReservationID}, AttractionID: {AttractionID}, TicketDate: {TicketDate.Date}, Price: {Price}";
        }

        public string ReservationInfo()
        {
            return "Attraction Ticket\n\t" + ReservationID + ", Attraction " + AttractionID + ", $" + Price + ", " + TicketDate.Date; 
        }
    }
}
