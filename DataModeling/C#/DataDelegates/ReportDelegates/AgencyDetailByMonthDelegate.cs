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
    /// Provides functionality for connecting to SQL procedure for monthly report
    /// </summary>
    public class AgencyDetailByMonthDelegate : DataReaderDelegate<IReadOnlyList<string>>
    {
        public AgencyDetailByMonthDelegate() : base("Agency.DetailByMonth")
        {

        }

        public override IReadOnlyList<string> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32("Year")},{reader.GetInt32("Month").ToString()}," +
                    $" {reader.GetInt32("NumberOfTrips")}," +
                    $"{string.Format("{0:0.00}", reader.GetDouble("AverageTripsPerAgent"))}," +
                    $"${string.Format("{0:0.00}", reader.GetDouble("TotalSale"))}");
            }
            return rows;


        }
    }
}
