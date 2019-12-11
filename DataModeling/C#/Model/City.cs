using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class City
    {
        /// <summary>
        /// id of city
        /// </summary>
        public int CityID { get; }
        /// <summary>
        /// name of city
        /// </summary>
        public string CityName { get; }
        /// <summary>
        /// region of city
        /// </summary>
        public string Region { get; }
        /// <summary>
        /// country 
        /// </summary>
        public string Country { get; }

        public City(int cityID, string cityName, string region, string country)
        {
            CityID = cityID;
            CityName = cityName;
            Region = region;
            Country = country;
        }
        /// <summary>
        /// returns all properties as strings with commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"CityID: {CityID}, CityName: {CityName}, Region: {Region}, Country: {Country}";

        }
    }
}
