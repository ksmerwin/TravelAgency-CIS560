using DataAccess;
using DataModeling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataModeling
{
    /// <summary>
    /// Provides functionality for connecting to SQL procedure for getting a car agency given all info except its id
    /// </summary>
    public class CarsGetAgencyByNameDelegate : DataReaderDelegate<CarRental>
    {
        private readonly string agencyName;
        private readonly int cityID;

        public CarsGetAgencyByNameDelegate(string agencyName, int cityID)
           : base("Cars.GetAgencyByName")
        {
            this.agencyName = agencyName;
            this.cityID = cityID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("AgencyName", agencyName);
            command.Parameters.AddWithValue("cityID", cityID);

        }

        public override CarRental Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new CarRental(reader.GetInt32("CarRentalID"),
                agencyName,cityID
               );
        }
    }
}

