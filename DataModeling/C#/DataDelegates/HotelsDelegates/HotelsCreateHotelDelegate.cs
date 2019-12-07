using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class HotelsCreateHotelDelegate : NonQueryDataDelegate<Hotel>
    {
        public readonly int hotelID;
        public readonly string fulladdress;
        public readonly string name;
        public readonly int cityID;

        public HotelsCreateHotelDelegate(string name, int cityID, string fulladdress)
            :base("Hotels.CreateHotel")
        {
            this.name = name;
            this.cityID = cityID;
            this.fulladdress = fulladdress;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            
            command.Parameters.AddWithValue("CityID", cityID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("FullAddress", fulladdress);


            var p = command.Parameters.Add("HotelID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Hotel Translate(SqlCommand command)
        {
            return new Hotel((int)command.Parameters["HotelID"].Value, cityID, name, fulladdress);
        }

    }
}
