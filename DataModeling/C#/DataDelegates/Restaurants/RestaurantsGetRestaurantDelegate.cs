using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class RestaurantsGetRestaurantDelegate : DataReaderDelegate<Restaurant>
    {
        private readonly int restaurantID;

        public RestaurantsGetRestaurantDelegate(int restaurantID)
           : base("Restaurants.GetRestaurant")
        {
            this.restaurantID = restaurantID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("RestaurantID", restaurantID);
        }

        public override Restaurant Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Restaurant(restaurantID,
               reader.GetString("Name"),
               reader.GetInt32("CityID")               
               );
        }
    }
}