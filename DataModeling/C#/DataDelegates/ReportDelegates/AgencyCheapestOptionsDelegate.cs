using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModeling.Model;
using System.Globalization;

namespace DataModeling
{
    /// <summary>
    /// Provides functionality for connecting to SQL procedure for cheapest options report
    /// </summary>
    public class AgencyCheapestOptionsDelegate : DataReaderDelegate<IReadOnlyList<string>>
    {
        public AgencyCheapestOptionsDelegate() : base("Agency.CheapestOptions")
        {

        }

        public override IReadOnlyList<string> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<string> rows = new List<string>();

            while(reader.Read())
            {                
                rows.Add($"{reader.GetString("CityName")}, " + 
                    $"{reader.GetString("Country")}-{reader.GetString("Hotel")} " +
                    $"${string.Format("{0:0.00}", reader.GetDouble("CheapestHotelPrices"))}-{reader.GetString("Attraction")} " +
                    $"${string.Format("{0:0.00}", reader.GetDouble("CheapestAttractionPrices"))}");
            }
            return rows;
        }
    }
}
