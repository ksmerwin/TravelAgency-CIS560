using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class Agent
    {
        /// <summary>
        /// gets id of agent
        /// </summary>
        public int AgentID { get; }

        /// <summary>
        /// gets name of agent
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// gets salary of agent
        /// </summary>
        public double Salary { get; }
        /// <summary>
        /// Represents if the agent has been deleted or not
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Constructor for the agent
        /// </summary>
        /// <param name="aID"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="isDeleted"></param>
        public Agent(int aID, string name, double salary, bool isDeleted)
        {
            AgentID = aID;
            Name = name;
            Salary = salary;
            IsDeleted = isDeleted;
        }
        /// <summary>
        /// Overload constructor if not deleted
        /// </summary>
        /// <param name="aID"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        public Agent(int aID, string name, double salary)
        {
            AgentID = aID;
            Name = name;
            Salary = salary;
            IsDeleted = false;
        }

        /// <summary>
        /// Returns id and name
        /// </summary>
        public string AgentSimpleInfo
        {
            get
            {
                return AgentID + ", " + Name;
            }
        }

        /// <summary>
        /// Returns agent class as a string with commas between each attribute
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("AgentID: " + AgentID);
            result.Append(", ");
            result.Append("Name: " + Name);
            result.Append(", ");
            result.Append("Salary: " + Salary);
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
