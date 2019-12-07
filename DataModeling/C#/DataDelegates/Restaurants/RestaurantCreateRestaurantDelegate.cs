using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class RestaurantCreateRestaurantDelegate : NonQueryDataDelegate<Restaurant>
    {
        public readonly int cityID;
        public readonly string restName;


        public RestaurantCreateRestaurantDelegate(int  cityID, string restName)
            : base("Restaurants.CreateRestaurant")
        {
            this.cityID = cityID;
            this.restName = restName;

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);


            command.Parameters.AddWithValue("Name", restName);
            command.Parameters.AddWithValue("CityID", cityID);



            var p = command.Parameters.Add("RestaurantID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Restaurant Translate(SqlCommand command)
        {
            return new Restaurant((int)command.Parameters["RestaurantID"].Value, restName, cityID);
        }

    }
}
