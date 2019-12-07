using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class HotelsGetHotelDelegate : DataReaderDelegate<Hotel>
    {
        private readonly int hotelID;

        public HotelsGetHotelDelegate(int hotelID)
           : base("Hotels.GetHotel")
        {
            this.hotelID = hotelID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("HotelID", hotelID);
        }

        public override Hotel Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Hotel(hotelID,              
               reader.GetInt32("CityID"),
               reader.GetString("Name"),
               reader.GetString("FullAddress"));
        }
    }
}