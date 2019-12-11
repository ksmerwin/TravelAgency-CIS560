using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class CarRental
    {
        /// <summary>
        /// id of car rental
        /// </summary>
        public int CarRentalID { get; }

        /// <summary>
        /// name of agency
        /// </summary>
        public string AgencyName { get; }

        /// <summary>
        /// city id
        /// </summary>
        public int CityID { get; }

        public CarRental(int carRentalID, string agencyName, int cityID)
        {
            CarRentalID = carRentalID;
            AgencyName = agencyName;
            CityID = cityID;
        }
        /// <summary>
        /// returns properties with commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"CarRentalID: {CarRentalID}, AgencyName: {AgencyName}, CityID: {CityID}";

        }

    }
}
