using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    /// <summary>
    /// Provides functionality for connecting to SQL procedure for getting a city given all info except its id
    /// </summary>
    public class LocationGetCityDelegate : DataReaderDelegate<City>
    {
        private readonly int cityID;
        private readonly string country;
        private readonly string region;
        private readonly string cityName;

        public LocationGetCityDelegate(string cityName, string country, string region)
                  : base("Location.GetCitiesByName")
        {            
            this.cityName = cityName;
            this.country = country;
            this.region = region;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("CityName", cityName);
            command.Parameters.AddWithValue("Region", region);
            command.Parameters.AddWithValue("Country", country);

        }

        public override City Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new City(reader.GetInt32("CityID"), cityName, region, country);           
        }
    }
}