using DataAccess;
using DataModeling.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{
    public class AgencyGetAgentsDelegate : DataReaderDelegate<IReadOnlyList<Agent>>
    {
        public AgencyGetAgentsDelegate()
           : base("Agency.GetAgents")
        {
        }

        public override IReadOnlyList<Agent> Translate(SqlCommand command, IDataRowReader reader)
        {
            var Agents = new List<Agent>();

            while (reader.Read())
            {
                Agents.Add(new Agent(
                   reader.GetInt32("AgentID"),
                   reader.GetString("Name"),
                   reader.GetDouble("Salary")));
            }

            return Agents;
        }
    }
}