using DataAccess;
using DataModeling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{
    public class AgencyGetCustomerDelegate : DataReaderDelegate<Customer>
    {
        private readonly int customerID;

        public AgencyGetCustomerDelegate(int customerID)
           : base("Agency.GetCustomer")
        {
            this.customerID = customerID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("CustomerID", customerID);
        }

        public override Customer Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Customer(customerID,
                reader.GetString("Name"),
               reader.GetDouble("Budget"),
               reader.GetInt32("Age"),
               reader.GetString("Sex"),
               reader.GetInt32("ContactID")               
               );
        }
    }
}