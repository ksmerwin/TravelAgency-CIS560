using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace DataModeling
{
    public class AgencySaveCustomerContactInfoDelegate : DataDelegate
    {
        private readonly int contactID;
        private readonly string billingAddress;
        private readonly string phone;
        private readonly string email;
        private readonly int cityID;
       

        public AgencySaveCustomerContactInfoDelegate(int contactID, string billingAddress, string phone, string email, int cityID)
           : base("Agency.SaveCustomerContactInfo")
        {
            this.contactID = contactID;
            this.billingAddress = billingAddress;
            this.phone = phone;
            this.email = email;
            this.cityID = cityID;

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ContactID", contactID);
            command.Parameters.AddWithValue("BillingAddress", billingAddress);
            command.Parameters.AddWithValue("Phone", phone);
            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("CityID", cityID);
           
        }
    }
}