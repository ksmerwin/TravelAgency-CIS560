using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class AgencyGetTripDelegate : DataReaderDelegate<IReadOnlyList<Trip>>
    {
        private readonly int customerID;
        private readonly int agentID;

        public AgencyGetTripDelegate(int customerID, int agentID) : base("Agency.GetTrip")
        {
            this.customerID = customerID;
            this.agentID = agentID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.Add("CustomerID", SqlDbType.Int).Value = customerID;
            command.Parameters.Add("AgentID", SqlDbType.Int).Value = agentID;
        }

        public override IReadOnlyList<Trip> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<Trip> trips = new List<Trip>();

            //Get all trips associated with agent and customer
            while(reader.Read())
            {
                trips.Add(new Trip(reader.GetInt32("TripID"), customerID, reader.GetDateTimeOffset("DateCreated"), agentID));
            }
            return trips;
        }
    }
}
