using DataAccess;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class AgencyGetCustomersDelegate : DataReaderDelegate<IReadOnlyList<Customer>>
    {
        public AgencyGetCustomersDelegate()
           : base("Agency.GetCustomers")
        {
        }

        public override IReadOnlyList<Customer> Translate(SqlCommand command, IDataRowReader reader)
        {
            var customers = new List<Customer>();

            while (reader.Read())
            {
                customers.Add(new Customer(                   
                   reader.GetInt32("CustomerID"), 
                   reader.GetString("Name"),
                   reader.GetDouble("Budget"),
                   reader.GetInt32("Age"),
                   reader.GetString("Sex"),
                   reader.GetInt32("ContactID")
                   ));
            }

            return customers;
        }
    }
}