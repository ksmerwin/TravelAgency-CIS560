using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Trip
    {
        /// <summary>
        /// gets trip ID
        /// </summary>
        public int TripID { get; }

        /// <summary>
        /// gets customer ID
        /// </summary>
        public int CustomerID { get; }

        /// <summary>
        /// gets whether trip was deleted
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// gets date trip was created
        /// </summary>
        public DateTimeOffset DateCreated { get; }

        /// <summary>
        /// gets agent ID
        /// </summary>
        public int AgentID { get; }

        public Trip(int tripID, int customerID, bool isDeleted, DateTimeOffset dateCreated, int agentID)
        {
            TripID = tripID;
            CustomerID = customerID;
            IsDeleted = isDeleted;
            DateCreated = dateCreated;
            AgentID = agentID;
     
        }

        public Trip(int tripID, int customerID, DateTimeOffset dateCreated, int agentID)
        {
            TripID = tripID;
            CustomerID = customerID;
            DateCreated = dateCreated;
            AgentID = agentID;
            IsDeleted = false;
        }

        /// <summary>
        /// returns trip object with commas in between properties
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append("DateCreated: " + DateCreated.Date);
            result.Append(", ");
            result.Append("TripID: " + TripID);
            result.Append(", ");
            result.Append("AgentID: " + AgentID);
            result.Append(", ");
            result.Append("CustomerID: " + CustomerID);
            result.Append(", ");
            

            if (IsDeleted)
            {
                result.Append("Deleted");
            }
            else
            {
                result.Append("Not Deleted");
            }
            return result.ToString();

        }
    }
}
