using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Restaurant
    {
        /// <summary>
        /// id of restaurant 
        /// </summary>
        public int RestaurantID { get;  }

        /// <summary>
        /// name of restaurant
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// id of city
        /// </summary>
        public int CityID { get; }

        public Restaurant(int restaurantID, string name, int cityID)
        {
            RestaurantID = restaurantID;
            Name = name;
            CityID = cityID;
        }

        /// <summary>
        /// restaurant properties's commas in between
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"RestaurantID: {RestaurantID}, Name: {Name}, CityID: {CityID}";

        }
    }
}
