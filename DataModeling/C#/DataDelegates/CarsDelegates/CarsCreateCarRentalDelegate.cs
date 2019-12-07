using DataAccess;
using DataModeling.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DataModeling
{
    public class CarsCreateCarRentalDelegate : NonQueryDataDelegate<CarRental>
    {
        public readonly string AgencyName;
        public readonly int CityID;

        public CarsCreateCarRentalDelegate(string AgencyName, int CityID)
            : base("Cars.CreateCarRental")
        {
            this.AgencyName = AgencyName;
            this.CityID = CityID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("AgencyName", AgencyName);
            command.Parameters.AddWithValue("CityID", CityID);

            var p = command.Parameters.Add("CarRentalID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override CarRental Translate(SqlCommand command)
        {
            return new CarRental((int)command.Parameters["CarRentalID"].Value, AgencyName, CityID);
        }
    }

}
