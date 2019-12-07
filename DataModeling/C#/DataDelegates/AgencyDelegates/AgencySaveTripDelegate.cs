using DataAccess;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DataModeling
{
    public class AgencySaveTripDelegate : DataDelegate
    {
        private readonly int tripID;
        private readonly int customerID;
        private readonly int isDeleted;
        private readonly DateTimeOffset dateCreated;
        private readonly int agentID;


        public AgencySaveTripDelegate(int tripID, int customerID, int isDeleted, DateTimeOffset dateCreated, int agentID)
           : base("Agency.SaveTrip")
        {
            this.tripID = tripID;
            this.customerID = customerID;
            this.isDeleted = isDeleted;
            this.dateCreated = dateCreated;
            this.agentID = agentID;

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TripID", tripID);
            command.Parameters.AddWithValue("CustomerID", customerID);
            command.Parameters.AddWithValue("IsDeleted", isDeleted);
            command.Parameters.AddWithValue("DateCreated", dateCreated);
            command.Parameters.AddWithValue("AgentID", agentID);

        }
    }
}