using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class HotelsCreateHotelReservationDelegate : NonQueryDataDelegate<HotelReservation>
    {
        public readonly int tripID;
        public readonly int hotelID;
        public readonly System.DateTime checkindate;
        public readonly float price;

        public HotelsCreateHotelReservationDelegate(int tripID, int hotelID, System.DateTime checkInDate, float roomPrice)
            : base("Hotels.CreateHotelReservation")
        {
            this.tripID = tripID;
            this.hotelID = hotelID;
            this.checkindate = checkInDate;
            this.price = roomPrice;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TripID", tripID);
            command.Parameters.AddWithValue("HotelID", hotelID);
            command.Parameters.AddWithValue("CheckInDate", checkindate);
            command.Parameters.AddWithValue("Price", price);

            var p = command.Parameters.Add("ReservationID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override HotelReservation Translate(SqlCommand command)
        {
            return new HotelReservation((int)command.Parameters["ReservationID"].Value, hotelID, checkindate, price);
        }

    }
}
