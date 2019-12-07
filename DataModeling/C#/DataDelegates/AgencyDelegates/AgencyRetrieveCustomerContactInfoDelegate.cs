using DataAccess;
using DataModeling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{
    public class AgencyRetrieveCustomerContactInfoDelegate : DataReaderDelegate<ContactInfo>
    {
        private readonly int contactID;

        public AgencyRetrieveCustomerContactInfoDelegate(int contactID)
           : base("Agency.RetrieveCustomerContactInfo")
        {
            this.contactID = contactID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ContactID", contactID);
        }

        public override ContactInfo Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new ContactInfo(reader.GetInt32("ContactID"),
               reader.GetString("BillingAddress"),
               reader.GetString("Phone"),
               reader.GetString("Email"),
               reader.GetInt32("CityID")
               );
        }
    }
}