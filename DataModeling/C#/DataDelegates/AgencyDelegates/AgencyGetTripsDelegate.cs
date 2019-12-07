using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModeling.Model;
using DataAccess;
using System.Data.SqlClient;

namespace DataModeling
{
    public class AgencyGetTripsDelegate : DataReaderDelegate<IReadOnlyList<Trip>>
    {
        public AgencyGetTripsDelegate() : base("Agency.GetTrips")
        {

        }

        public override IReadOnlyList<Trip> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<Trip> trips = new List<Trip>();
            while (reader.Read())
            {
                trips.Add(new Trip(reader.GetInt32("TripID"),
                    reader.GetInt32("CustomerID"),
                    reader.GetDateTimeOffset("DateCreated"),
                    reader.GetInt32("AgentID")));
            }
            return trips;
        }        
    }
}
