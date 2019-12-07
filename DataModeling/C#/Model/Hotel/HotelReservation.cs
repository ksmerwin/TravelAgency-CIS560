using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class HotelReservation : IReservation
    {
        public int ReservationID { get; }

        public int HotelID { get; }

        public DateTime CheckinDate { get; }

        public double Price { get; }

        public HotelReservation(int reservationID, int hotelID, DateTime checkinDate, double price)
        {
            ReservationID = reservationID;
            HotelID = hotelID;
            CheckinDate = checkinDate;
            Price = price;
        }
        public override string ToString()
        {
            return $"ReservationID: {ReservationID}, HotelID: {HotelID}, CheckinDate: {CheckinDate.Date}, Price: {Price}";

        }

        public string ReservationInfo()
        {
            return $"Hotel Reservation\n\t{ReservationID}, Hotel {HotelID}, ${Price}, {CheckinDate.Date}";
        }
    }
}
