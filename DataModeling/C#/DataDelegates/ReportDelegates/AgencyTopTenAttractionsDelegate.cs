using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess;
using System.Globalization;

namespace DataModeling
{
    /// <summary>
    /// Provides functionality for connecting to SQL procedure for top ten attractions report
    /// </summary>
    public class AgencyTopTenAttractionsDelegate : DataReaderDelegate<IReadOnlyList<string>>
    {
        public AgencyTopTenAttractionsDelegate() : base("Agency.TopTenAttractions")
        {

        }

        public override IReadOnlyList<string> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<string> rows = new List<string>();

            while(reader.Read())
            {
                rows.Add($"{reader.GetInt32("AttractionID")}-{reader.GetString("Name")}-" +
                    $"{reader.GetInt32("NumberOfCustomers")}-{reader.GetString("CityName")}, " +
                    $"{reader.GetString("Country")}-${string.Format("{0:0.00}", reader.GetDouble("Price"))}");
            }
            return rows;
        }
    }
}
