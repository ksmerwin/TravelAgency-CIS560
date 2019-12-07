using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModeling.Model;
using System.Data.SqlClient;
using System.Data;

namespace DataModeling
{
    public class AgencyCreateTripDelegate : NonQueryDataDelegate<Trip>
    {
        private readonly int customerID;
        private readonly int agentID;

        public AgencyCreateTripDelegate(int customerID, int agentID) : base("Agency.CreateTrip")
        {
            this.customerID = customerID;
            this.agentID = agentID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.Add("CustomerID", SqlDbType.Int).Value = customerID;
            command.Parameters.Add("AgentID", SqlDbType.Int).Value = agentID;

            var p = command.Parameters.Add("TripID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            var d = command.Parameters.Add("DateCreated", SqlDbType.DateTimeOffset);
            d.Direction = ParameterDirection.Output;
        }

        public override Trip Translate(SqlCommand command)
        {
            return new Trip((int)command.Parameters["TripID"].Value, customerID, (DateTimeOffset)command.Parameters["DateCreated"].Value, agentID);
        }
    }
}
