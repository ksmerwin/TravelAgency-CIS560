using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class GetFlightDelegate : DataReaderDelegate<Flight>
    {
        private readonly int FlightID;
        public readonly string AirlineName;
        public readonly System.DateTime DepartureTime;
        public readonly int CityDepartureID;
        public readonly System.DateTime ArrivalTime;
        public readonly int CityArrivalID;
        

        public GetFlightDelegate(string airlineName, System.DateTime departureTime, int departureCityID, System.DateTime arrivalTime, int arrivalCityID)
           : base("Airlines.GetFlight")
        {
            this.AirlineName = airlineName;
            this.DepartureTime = departureTime;
            this.CityDepartureID = departureCityID;
            this.ArrivalTime = arrivalTime;
            this.CityArrivalID = arrivalCityID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("AirlineName", AirlineName);
            command.Parameters.AddWithValue("DepartureTime", DepartureTime);
            command.Parameters.AddWithValue("ArrivalTime", ArrivalTime);
            command.Parameters.AddWithValue("CityDepartureID", CityDepartureID);
            command.Parameters.AddWithValue("CityArrivalID", CityArrivalID);

        }

        public override Flight Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Flight(FlightID,
               reader.GetString("AirlineName"),
               reader.GetDateTime("DepartureTime"),
               reader.GetDateTime("ArrivalTime"),
               reader.GetInt32("CityDepatureID"),
               reader.GetInt32("CityArrivalID"));
        }
    }
}