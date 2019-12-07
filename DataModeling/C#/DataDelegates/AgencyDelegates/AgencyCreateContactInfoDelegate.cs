using DataAccess;
using DataModeling.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataModeling
{

    public class AgencyCreateContactInfoDelegate : NonQueryDataDelegate<ContactInfo>
    {
        public readonly string billingAddress;
        public readonly string email;
        public readonly string phone;
        public int cityId;

        public AgencyCreateContactInfoDelegate(string billingAddress, string email, string phone, int cityId)
            : base("Agency.CreateContactInfo")
        {
            this.billingAddress = billingAddress;
            this.email = email;
            this.phone = phone;
            this.cityId = cityId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("BillingAddress", billingAddress);
            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("Phone", phone);
            command.Parameters.AddWithValue("CityID", cityId);

            var p = command.Parameters.Add("ContactID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override ContactInfo Translate(SqlCommand command)
        {
            return new ContactInfo((int)command.Parameters["ContactID"].Value, billingAddress, phone, email, cityId);
        }
    }


}
