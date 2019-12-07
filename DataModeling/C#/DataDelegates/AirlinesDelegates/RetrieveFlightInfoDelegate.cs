using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class RetrieveFlightInfoDelegate : DataReaderDelegate<Flight>
    {
        private readonly int flightID;

        public RetrieveFlightInfoDelegate(int flightID)
           : base("Airlines.RetrieveFlightInfo")
        {
            this.flightID = flightID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("FlightID", flightID);
        }

        public override Flight Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Flight(reader.GetInt32("FlightID"),
               reader.GetString("AirlineName"),
               reader.GetDateTime("DepartureTime"),
               reader.GetDateTime("ArrivalTime"),               
               reader.GetInt32("CityDepartureID"),
               reader.GetInt32("CityArrivalID"));
        }
    }
}





