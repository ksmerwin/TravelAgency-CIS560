using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class HotelsFetchHotelDelegate : DataReaderDelegate<Hotel>
    {
        private readonly string name;
        private readonly int cityID;
        private readonly string fullAddress;

        public HotelsFetchHotelDelegate(string name, int cityID, string fullAddress)
           : base("Hotels.FetchHotel")
        {
            this.name = name;
            this.cityID = cityID;
            this.fullAddress = fullAddress;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("CityID", cityID);
            command.Parameters.AddWithValue("FullAddress", fullAddress);
        }

        public override Hotel Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Hotel(reader.GetInt32("HotelID"),
               cityID,
               name,
               fullAddress);
        }
    }
}