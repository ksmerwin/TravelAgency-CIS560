using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;
using System;

namespace DataModeling
{
    public class CreateAttractionTicketDelegate : NonQueryDataDelegate<AttractionTicket>
    {
        public readonly int tripID;
        public readonly int attractionID;
        public readonly DateTime ticketdate;
        public readonly float price;

        public CreateAttractionTicketDelegate(int tripID, int attractionID, DateTime TicketDate, float Price)
            : base("Attractions.CreateAttractionTicket")
        {
            this.tripID = tripID;
            this.attractionID = attractionID;
            this.ticketdate = TicketDate;
            this.price = Price;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TripID", tripID);
            command.Parameters.AddWithValue("AttractionID", attractionID);
            command.Parameters.AddWithValue("TicketDate", ticketdate);
            command.Parameters.AddWithValue("Price", price);


            var p = command.Parameters.Add("ReservationID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override AttractionTicket Translate(SqlCommand command)
        {
            return new AttractionTicket((int)command.Parameters["ReservationID"].Value, attractionID, ticketdate, price);
        }

    }
}
