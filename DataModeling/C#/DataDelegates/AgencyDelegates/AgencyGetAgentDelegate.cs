using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModeling.Model;
using System.Data.SqlClient;

namespace DataModeling
{
    public class AgencyGetAgentDelegate : DataReaderDelegate<Agent>
    {
        private readonly int agentID;

        public AgencyGetAgentDelegate(int agentID) : base("Agency.GetAgent")
        {
            this.agentID = agentID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("AgentID", agentID);
        }

        public override Agent Translate(SqlCommand command, IDataRowReader reader)
        {
            if(!reader.Read())
            {
                return null;
            }
            return new Agent(reader.GetInt32("AgentID"), reader.GetString("Name"), reader.GetDouble("Salary"));
        }
    }
}
