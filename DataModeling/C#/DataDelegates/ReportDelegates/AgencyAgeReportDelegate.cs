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
    /// Provides functionality for connecting to SQL procedure for age report
    /// </summary>
    public class AgencyAgeReportDelegate : DataReaderDelegate<IReadOnlyList<string>>
    {
        public AgencyAgeReportDelegate() : base("Agency.AgeReport")
        {

        }

        public override IReadOnlyList<string> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetString("AgeGroup")}," +
                    $"{reader.GetInt32("Count")}," +
                    $"${string.Format("{0:0.00}",reader.GetDouble("AverageBudget"))}," +
                    $"${string.Format("{0:0.00}", reader.GetDouble("LowestBudget"))}," +
                    $"${string.Format("{0:0.00}", reader.GetDouble("HighestBudget"))}," +
                    $"{reader.GetInt32("AverageAge")}," +
                    $"{reader.GetInt32("TripCount")}");
            }
            return rows;
        }
    }
}
