using DataAccess;
using DataModeling.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{

    public class AgencyCreateCustomerDelegate : NonQueryDataDelegate<Customer>
    {
        public readonly string name;
        public readonly float budget;
        public readonly int age;
        public readonly string sex;
        public readonly int contactId;
        

        public AgencyCreateCustomerDelegate(string name, float budget, int age, string sex, int contactId)
            : base("Agency.CreateCustomer")
        {
            this.name = name;
            this.budget = budget;
            this.age = age;
            this.sex = sex;
            this.contactId = contactId;
            
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Budget", budget);
            command.Parameters.AddWithValue("Age", age);
            command.Parameters.AddWithValue("Sex", sex);
            command.Parameters.AddWithValue("ContactID", contactId);
            var p = command.Parameters.Add("CustomerID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Customer Translate(SqlCommand command)
        {
            return new Customer((int)command.Parameters["CustomerID"].Value, name, budget, age, sex, contactId);
        }
    }


}
