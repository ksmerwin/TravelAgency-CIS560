using DataAccess;
using DataModeling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{
    /// <summary>
    /// Provides functionality for connecting to SQL procedure for getting a car rental agency given its id
    /// </summary>
    public class CarsGetAgencyByIDDelegate : DataReaderDelegate<CarRental>
    {
        private readonly int carRentalID;

        public CarsGetAgencyByIDDelegate(int carRentalID)
           : base("Cars.GetAgencyByID")
        {
            this.carRentalID = carRentalID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("CarRentalID", carRentalID);
        }

        public override CarRental Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new CarRental(carRentalID,
                reader.GetString("AgencyName"),
               reader.GetInt32("CityID")
               );
        }
    }
}
