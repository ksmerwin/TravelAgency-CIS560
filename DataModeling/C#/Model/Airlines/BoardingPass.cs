using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class BoardingPass : IReservation
    {
        public int ReservationID { get; }

        public int FlightID { get; }

        public double Price { get;  }

        public BoardingPass(int reservationID, int flightID, double price)
        {
            ReservationID = reservationID;
            Price = price;
            FlightID = flightID;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("ReservationID: " + ReservationID);
            result.Append(", ");
            result.Append("FlightID: " + FlightID);
            result.Append(", ");
            result.Append("Price: " + Price);

            return result.ToString();
        }

        public string ReservationInfo()
        {
            return $"Boarding Pass\n\t {ReservationID}, Flight {FlightID}, ${Price}"; 
        }
    }
}
