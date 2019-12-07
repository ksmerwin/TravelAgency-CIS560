using DataAccess;
using DataModeling.Model;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;

namespace DataModeling
{
    public class CarsCreateCarRentalReservationDelegate : NonQueryDataDelegate<CarRentalReservation>
    {
        private int tripID;
        private int carRentalID ;
        private DateTime rentalDate;
        private string model;
        private float price;

        public CarsCreateCarRentalReservationDelegate(int tripID, int carRentalID, DateTime rentalDate,
                                          string model, float price)
            : base("Cars.CreateCarRentalReservation")
        {
            this.tripID = tripID;
            this.carRentalID =carRentalID;
            this.rentalDate = rentalDate;
            this.model= model;
            this.price = price;
    }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TripID", tripID);
            command.Parameters.AddWithValue("CarRentalID", carRentalID);
            command.Parameters.AddWithValue("RentalDate", rentalDate);
            command.Parameters.AddWithValue("Model", model);
            command.Parameters.AddWithValue("Price", price);

            var p = command.Parameters.Add("ReservationID", SqlDbType.Int);
            p.Value = ParameterDirection.Output;
        }

        public override CarRentalReservation Translate(SqlCommand command)
        {
            return new CarRentalReservation((int)command.Parameters["ReservationID"].Value, carRentalID, rentalDate,model,price);
        }
    }

}

