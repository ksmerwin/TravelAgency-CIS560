using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class RestaurantReservation : IReservation
    {
        public int ReservationID { get; }

        public DateTime ReservationDate { get; }

        public int RestaurantID { get; }
        

        public RestaurantReservation(int reservationID, DateTime reservationDate, int restaurantID)
        {
            ReservationID = reservationID;
            ReservationDate = reservationDate;
            RestaurantID = restaurantID;            
        }
        public override string ToString()
        {
            return $"ReservationID: {ReservationID}, ReservationDate: {ReservationDate}, RestaurantID: {RestaurantID}";
        }

        public string ReservationInfo()
        {
            return $"Restaurant Reservation\n\t {ReservationID}, Restaurant {ReservationID}, {ReservationDate}"; 
        }
    }
}
