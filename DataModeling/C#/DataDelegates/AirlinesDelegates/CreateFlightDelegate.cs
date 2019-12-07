using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;
using System;

namespace DataModeling
{
    public class CreateFlightDelegate : NonQueryDataDelegate<Flight>
    {
        public readonly int flightID;
        public readonly string airlinename;
        public readonly DateTime departuretime;
        public readonly DateTime arrivaltime;
        public readonly int citydepartureID;
        public readonly int cityarrivalID;

        public CreateFlightDelegate(string airlineName, DateTime departureTime, DateTime arrivalTime, int cityDepartureID, int cityArrivalID)
            : base("Airlines.CreateFlight")
        {
            this.airlinename = airlineName;
            this.departuretime = departureTime;
            this.arrivaltime = arrivalTime;
            this.cityarrivalID = cityArrivalID;
            this.citydepartureID = cityDepartureID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("AirlineName", airlinename);
            command.Parameters.AddWithValue("DepartureTime", departuretime);
            command.Parameters.AddWithValue("ArrivalTime", arrivaltime);
            command.Parameters.AddWithValue("CityDepartureID", citydepartureID);
            command.Parameters.AddWithValue("CityArrivalID", cityarrivalID);            

            var p = command.Parameters.Add("FlightID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Flight Translate(SqlCommand command)
        {
            return new Flight((int)command.Parameters["FlightID"].Value, airlinename, departuretime, arrivaltime, citydepartureID, cityarrivalID);
        }

    }
}
