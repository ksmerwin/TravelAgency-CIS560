using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Reservation
    {
        /// <summary>
        /// gets id of reservation
        /// </summary>
        public int ReservationID { get; }

        /// <summary>
        /// gets date reservation is created
        /// </summary>
        public DateTimeOffset DateCreated { get; }

        /// <summary>
        /// gets whether reservation was deleted
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// gets whether car has reservation
        /// </summary>
        public bool CarReservation { get; }

        /// <summary>
        /// gets whether hotel has reservation
        /// </summary>
        public bool HotelReservation { get; }

        /// <summary>
        /// gets whether there is a boarding pass
        /// </summary>
        public bool BoardingPass { get; }

        /// <summary>
        /// gets whether there is an attraction ticket
        /// </summary>
        public bool AttractionTicket { get; }

        /// <summary>
        /// gets whether there is a restaurant reservation
        /// </summary>
        public bool RestaurantReservation { get; }

        /// <summary>
        /// gets tripID
        /// </summary>
        public int TripID { get; }

     
        public Reservation(int reservationID, DateTimeOffset dateCreated, bool isDeleted, bool carReservation, bool hotelReservation, bool boardingPass, bool attractionTicket, bool restaurantReservation, int tripID)
        {
            ReservationID = reservationID;
            DateCreated = dateCreated;
            IsDeleted = isDeleted;
            CarReservation = carReservation;
            HotelReservation = hotelReservation;
            BoardingPass = boardingPass;
            AttractionTicket = attractionTicket;
            RestaurantReservation = restaurantReservation;
            TripID = tripID;

        }

        public Reservation(int reservationID, DateTimeOffset dateCreated, bool carReservation, bool hotelReservation, bool boardingPass, bool attractionTicket, bool restaurantReservation, int tripID)
        {
            ReservationID = reservationID;
            DateCreated = dateCreated;
            IsDeleted = false;
            CarReservation = carReservation;
            HotelReservation = hotelReservation;
            BoardingPass = boardingPass;
            AttractionTicket = attractionTicket;
            RestaurantReservation = restaurantReservation;
            TripID = tripID;

        }

        /// <summary>
        /// returns reservation properties with commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("ReservationID: " + ReservationID);
            result.Append(", ");
            result.Append("DateCreated: " + DateCreated.Date);
            result.Append(", ");
            result.Append("TripID: " + TripID);
            result.Append(", ");
            if(CarReservation)
            {
                result.Append("Has Car Reservation");
            }
            else
            {
                result.Append("No Car Reservation");
            }
            result.Append(", ");
            if (HotelReservation)
            {
                result.Append("Has Hotel Reservation");
            }
            else
            {
                result.Append("No Hotel Reservation");
            }
            result.Append(", ");
            if (AttractionTicket)
            {
                result.Append("Has Attraction Ticket");
            }
            else
            {
                result.Append("No Attraction Ticket");
            }
            result.Append(", ");
            if (RestaurantReservation)
            {
                result.Append("Has Restaurant Reservation");
            }
            else
            {
                result.Append("No Restaurant Reservation");
            }
            result.Append(", ");
            if (BoardingPass)
            {
                result.Append("Has Boarding Pass");
            }
            else
            {
                result.Append("No Boarding Pass");
            }
            result.Append(", ");
            if (IsDeleted)
            {
                result.Append("Deleted");
            }
            else
            {
                result.Append("Not Deleted");
            }
            return result.ToString();

        }









    }
}
