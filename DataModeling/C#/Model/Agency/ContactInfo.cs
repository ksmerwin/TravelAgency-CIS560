using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling.Model
{
    public class ContactInfo
    {
        /// <summary>
        /// gets id of contact
        /// </summary>
        public int ContactID { get; }

        /// <summary>
        /// gets billing address
        /// </summary>
        public string BillingAddress { get; }

        /// <summary>
        /// gets phone number
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// gets email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// gets cityID
        /// </summary>
        public int CityID { get; }

        /// <summary>
        /// constructs contact info object
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="billingAddress"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="cityID"></param>
        public ContactInfo(int contactID, string billingAddress, string phone, string email, int cityID)
        {
            ContactID = contactID;
            BillingAddress = billingAddress;
            Phone = phone;
            Email = email;
            CityID = cityID;
        }

        /// <summary>
        /// gets phone, email, and billing addresss seperated by commas
        /// </summary>
        public string SimpleContactInfo
        {
            get
            {
                return Phone + ", " + Email + ", " + BillingAddress;
            }
        }

        /// <summary>
        /// Returns contact info properties seperated by commas
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Contact ID: " + ContactID);
            result.Append(", ");
            result.Append("BillingAddress: " + BillingAddress);
            result.Append(", ");
            result.Append("Phone: " + Phone);
            result.Append(", ");
            result.Append("Email: " + Email);
            result.Append(", ");
            result.Append("CityID: " + CityID);

            return result.ToString();
        }
    }
}
