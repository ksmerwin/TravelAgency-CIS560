using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    /// <summary>
    /// Provides functionality for connecting to the SQL procedure for getting an attraction given all info except its id
    /// </summary>
    public class GetAttractionByNameDelegate : DataReaderDelegate<Attraction>
    {
        private readonly string name;
        private readonly int cityID;

        public GetAttractionByNameDelegate(string name, int cityID) : base("Attractions.GetAttractionByName")
        {
            this.name = name;
            this.cityID = cityID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("CityID", cityID);
        }

        public override Attraction Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Attraction(reader.GetInt32("AttractionID"), name, cityID);
        }
    }
}
