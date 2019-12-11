using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Flight
    {
        /// <summary>
        /// id of flight
        /// </summary>
        public int FlightID { get;  }

        /// <summary>
        /// name of airline
        /// </summary>
        public string AirlineName { get; }
        /// <summary>
        /// time of departure
        /// </summary>
        public DateTime DepartureTime { get; }
        /// <summary>
        /// time of arrival
        /// </summary>
        public DateTime ArrivalTime { get; }
        /// <summary>
        /// city departure id
        /// </summary>
        public int CityDepartureID { get; }
        /// <summary>
        /// city arrival id
        /// </summary>
        public int CityArrivalID { get; }
        

        public Flight(int flightID, string airlineName, DateTime departureTime, DateTime arrivalTime, int cityDepartureID, int cityArrivalID)
        {
            FlightID = flightID;
            AirlineName = airlineName;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            CityDepartureID = cityDepartureID;
            CityArrivalID = cityArrivalID;            
        }

        /// <summary>
        /// returns all properties with commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"FlightID: {FlightID}, AirlineName: {AirlineName}, DepartureTime: {DepartureTime}, ArrivalTime: {ArrivalTime}, CityDepartureID: {CityArrivalID}, CityArrivalID: {CityArrivalID}";
        }
    }
}
