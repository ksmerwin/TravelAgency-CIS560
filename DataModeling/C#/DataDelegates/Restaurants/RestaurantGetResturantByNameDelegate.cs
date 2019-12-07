using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
   public class RestaurantGetResturantByNameDelegate : DataReaderDelegate<Restaurant>
    {
        private readonly int cityID;
        private readonly string restaurantName;

        public RestaurantGetResturantByNameDelegate(string restaurantName, int cityID)
           : base("Restaurants.GetRestaurantByName")
        {
            this.restaurantName = restaurantName;
            this.cityID = cityID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", restaurantName);
            command.Parameters.AddWithValue("CityID", cityID);

        }

        public override Restaurant Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Restaurant(reader.GetInt32("RestaurantID"),
               restaurantName, cityID
               ); 
        }
    }
}