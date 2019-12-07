using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModeling.Model;

namespace DataModeling
{
    public class AgencyGetReservationsDelegate : DataReaderDelegate<IReadOnlyList<Reservation>>
    {
        private int tripID;

        public AgencyGetReservationsDelegate(int tripID) : base("Agency.GetReservations")
        {
            this.tripID = tripID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TripID", tripID);
        }

        public override IReadOnlyList<Reservation> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<Reservation> reservations = new List<Reservation>();
            while(reader.Read())
            {
                reservations.Add(new Reservation(reader.GetInt32("ReservationID"),
                                                reader.GetDateTimeOffset("DateCreated"),
                                                reader.GetBitToBool("CarReservation"),
                                                reader.GetBitToBool("HotelReservation"),
                                                reader.GetBitToBool("BoardingPass"),
                                                reader.GetBitToBool("AttractionTicket"),
                                                reader.GetBitToBool("RestaurantReservation"),
                                                tripID));
            }
            return reservations;
        }
    }
}
