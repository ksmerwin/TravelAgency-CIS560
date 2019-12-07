using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModeling;
using DataModeling.Model;

namespace DataModeling
{
    public class AgencyFetchTripDelegate : DataReaderDelegate<Trip>
    {
        private readonly int tripID;

        public AgencyFetchTripDelegate(int tripID) : base("Agency.FetchTrip")
        {
            this.tripID = tripID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TripID", tripID);
        }

        public override Trip Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;
            return new Trip(tripID, 
                reader.GetInt32("CustomerID"), 
                reader.GetDateTimeOffset("DateCreated"), 
                reader.GetInt32("AgentID"));
        }
    }
}
