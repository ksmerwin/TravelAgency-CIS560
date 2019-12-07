using DataAccess;
using DataModeling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{
    public class AgencyRetrieveAgentTripsDelegate : DataReaderDelegate<IReadOnlyList<Trip>>
    {
        private readonly int AgentID;

        public AgencyRetrieveAgentTripsDelegate(int AgentID)
           : base("Agency.RetrieveAgentTrips")
        {
            this.AgentID = AgentID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("AgentID", AgentID);
        }

        public override IReadOnlyList<Trip> Translate(SqlCommand command, IDataRowReader reader)
        {
             List<Trip> trips = new List<Trip>();

             while(reader.Read())
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