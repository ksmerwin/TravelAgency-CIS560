using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class RestaurantsGetRestaurantReservationDelegate : DataReaderDelegate<RestaurantReservation>
    {
        private readonly int reservationID;

        public RestaurantsGetRestaurantReservationDelegate(int reservationID)
           : base("Restaurants.GetRestaurantReservation")
        {
            this.reservationID = reservationID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ReservationID", reservationID);
        }

        public override RestaurantReservation Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null; ;

            return new RestaurantReservation(reader.GetInt32("ReservationID"),
               reader.GetDateTime("ReservationDate"),
               reservationID);
        }
    }
}