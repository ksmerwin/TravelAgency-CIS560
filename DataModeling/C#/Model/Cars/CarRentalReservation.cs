using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class CarRentalReservation : IReservation
    {
        public int ReservationID { get; }

        public int CarRentalID { get; }

        public DateTime RentalDate { get; }

        public string Model { get; }

        public double Price { get; }

        public CarRentalReservation(int reservationID, int carRentalID, DateTime rentalDate, string model, double price)
        {
            ReservationID = reservationID;
            CarRentalID = carRentalID;
            RentalDate = rentalDate;
            Model = model;
            Price = price;
        }
        public override string ToString()
        {
            return $"ReservationID: {ReservationID}, CarRentalID: {CarRentalID}, RentalDate: {RentalDate.Date}, Model: {Model}, Price: {Price}";
        }

        public string ReservationInfo()
        {
            return $"Car Rental Reservation\n\t{ReservationID}, Car Rental Agency {CarRentalID}, Model {Model}, ${Price}, {RentalDate.Date}"; 
        }
    }
}
