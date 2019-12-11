using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Hotel
    {
        /// <summary>
        /// id of hotel
        /// </summary>
        public int HotelID { get; }
        /// <summary>
        /// id of city
        /// </summary>
        public int CityID { get;  }

        /// <summary>
        /// name of hotel
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// address of hotel
        /// </summary>
        public string FullAddress { get;  }

        public Hotel(int hotelID, int cityID, string name, string fullAddress)
        {
            HotelID = hotelID;
            CityID = cityID;
            Name = name;
            FullAddress = fullAddress;
        }

        /// <summary>
        /// hotel object with commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"HotelID: {HotelID}, CityID: {CityID}, Name: {Name}, FullAddress: {FullAddress}";

        }

    }
}
