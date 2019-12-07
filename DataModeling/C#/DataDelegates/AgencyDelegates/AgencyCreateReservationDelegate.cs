using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;
using System;

namespace DataModeling
{
    public class AgencyCreateReservationDelegate : NonQueryDataDelegate<Reservation>
    {                       
        public readonly int tripID;
        public bool carreservation;
        public bool hotelreservation;
        public bool boardingpass;
        public bool attractionticket;
        public bool restaurantreservation;

        public AgencyCreateReservationDelegate( int tripID, bool carreservation, bool hotelreservation, bool boardingpass, bool attractionticket, bool restaurantreservation)
            : base("Agency.CreateReservation")
        {
            this.tripID = tripID;            
            this.carreservation = false;
            this.hotelreservation = false;
            this.boardingpass = false;
            this.attractionticket = false;
            this.restaurantreservation = false;
            

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            
            command.Parameters.AddWithValue("CarReservation", carreservation);
            command.Parameters.AddWithValue("HotelReservation", hotelreservation);
            command.Parameters.AddWithValue("BoardingPass", boardingpass);
            command.Parameters.AddWithValue("AttractionTicket", attractionticket);
            command.Parameters.AddWithValue("RestaurantReservation", restaurantreservation);
            command.Parameters.AddWithValue("TripID", tripID);

            var p = command.Parameters.Add("ReservationID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            var d = command.Parameters.Add("DateCreated", SqlDbType.DateTimeOffset);
            d.Direction = ParameterDirection.Output;
        }

        public override Reservation Translate(SqlCommand command)
        {
            return new Reservation(
                (int)command.Parameters["ReservationID"].Value,
                (DateTimeOffset)command.Parameters["DateCreated"].Value, 
                carreservation, 
                hotelreservation, 
                boardingpass, 
                attractionticket, 
                restaurantreservation, 
                tripID);
        }

    }
}
