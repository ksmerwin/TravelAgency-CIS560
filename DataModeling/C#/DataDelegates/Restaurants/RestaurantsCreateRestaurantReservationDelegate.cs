using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;
using System;
namespace DataModeling
{
    public class RestaurantsCreateRestaurantReservationDelegate : NonQueryDataDelegate<RestaurantReservation>
    {
        public readonly int tripID;
        public readonly int restaurantID;
        public readonly DateTime date;


        public RestaurantsCreateRestaurantReservationDelegate(int tripID, int restaurantID,DateTime date)
            : base("Restaurants.CreateRestaurantReservation")
        {
            this.tripID = tripID;
            this.restaurantID = restaurantID;
            this.date = date;

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);


            command.Parameters.AddWithValue("TripID", tripID);
            command.Parameters.AddWithValue("ReservationDate", date);
            command.Parameters.AddWithValue("RestaurantID", restaurantID);

            var p = command.Parameters.Add("ReservationID", SqlDbType.Int);
            p.Value = ParameterDirection.Output;
            
        }

        public override RestaurantReservation Translate(SqlCommand command)
        {
            return new RestaurantReservation((int)command.Parameters["ReservationID"].Value, date, restaurantID);
        }

    }
}
