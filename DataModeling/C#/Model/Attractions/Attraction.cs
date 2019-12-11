using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Attraction
    {
        /// <summary>
        /// attraction id
        /// </summary>
        public int AttractionID { get; }

        /// <summary>
        /// name of attraction
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// city id
        /// </summary>
        public int CityID { get; }

        public Attraction (int attractionID, string name, int cityID)
        {
            AttractionID = attractionID;
            Name = name;
            CityID = cityID;
        }
        /// <summary>
        /// returns all properties with commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"AttractionID: {AttractionID}, Name: {Name}, CityID: {CityID}";
        }
    }
}
