using DataAccess;
using DataModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataModeling.Model;
namespace UserInterface
{
    /// <summary>
    /// Interaction logic for NewCustomerScreen.xaml
    /// </summary>
    public partial class NewCustomerScreen : Page
    {
        private string connectionString;

        public NewCustomerScreen(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Return to the Trip Setup Screen when the user clicks "Done" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Done_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new TripSetupScreen(connectionString));
        }

        /// <summary>
        /// Add the customer to database if valid inputs when the user clicks "Add Customer" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddCustomer_Click(object sender, RoutedEventArgs args)
        {
            if(CheckValidInputs())
            {
                string name = Check.FormatName(uxFirstName.Text) + " " + Check.FormatName(uxLastName.Text);
                float budget = float.Parse(uxBudget.Text);
                int age = int.Parse(uxAge.Text);
                string sex = (bool)uxMale.IsChecked ? "Male" : "Female";

                string address = uxAddress.Text + "\n" + Check.FormatName(uxCity.Text) + ", " + uxZipcode.Text;
                string phone = uxAreaCode.Text + uxFirst3PhoneDigits.Text + uxLast4PhoneDigits.Text;
                string email = uxEmail.Text;

                string city = Check.FormatName(uxCity.Text);
                string region = Check.FormatName(uxRegion.Text);
                string country = Check.FormatName(uxCountry.Text);

                // CONNNECT
                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);
                LocationGetCityDelegate getCity = new LocationGetCityDelegate(city, country, region);
                int cityID = 0;

                // Lookup city using city, region, country
                // if city == null
                //      create city
                //      cityID = newly created city
                // else
                //      cityID = found city
                City c = executor.ExecuteReader(getCity);
                if (c == null)
                {
                    LocationCreateCityDelegate createsCity = new LocationCreateCityDelegate(city, region, country);
                    c = executor.ExecuteNonQuery(createsCity);
                    cityID = c.CityID;
                }
                else
                {
                    cityID = c.CityID;
                }
                // CONNECT
                int contactID = 0;
                int customerID = 0;
                // Create new contact info using address, phone, email, cityID
                AgencyCreateContactInfoDelegate saveInfo = new AgencyCreateContactInfoDelegate(address, phone, email, cityID);
                // contactID = newly created contact
                ContactInfo contactId = (ContactInfo)executor.ExecuteNonQuery(saveInfo);
                // CONNECT
                contactID = contactId.ContactID;
                AgencyCreateCustomerDelegate cd = new AgencyCreateCustomerDelegate(name, budget, age, sex, contactID);
                // Create new customer using budget, name, age, sex, contactID
                // customerID = newly created customer
                Customer customer = executor.ExecuteNonQuery(cd);
                customerID = customer.CustomerID;
                MessageBox.Show("Customer " + name + " has been successfully added. CustomerID = " + customerID);
            }
        }

        /// <summary>
        /// Checks whether valid inputs have been entered; if not, display appropriate message to user
        /// </summary>
        /// <returns>Whether all valid inputs have been entered</returns>
        private bool CheckValidInputs()
        {
            string message = "";
            if(Check.ValidSingleName("First Name", uxFirstName.Text, out message) && Check.ValidSingleName("Last Name", uxLastName.Text, out message)
                && Check.ValidPhoneNumber(uxAreaCode.Text, uxFirst3PhoneDigits.Text, uxLast4PhoneDigits.Text, out message)
                && Check.ValidAge(uxAge.Text, out message) && Check.ValidSex(uxMale.IsChecked, uxFemale.IsChecked, out message)
                && Check.ValidEmail(uxEmail.Text, out message) 
                && Check.ValidPositiveInt("Budget", uxBudget.Text, out message) && Check.NonNull("Address", uxAddress.Text, out message)
                && Check.ValidName("Country", uxCountry.Text, out message) && Check.ValidName("Region", uxRegion.Text, out message)
                && Check.ValidName("City", uxCity.Text, out message) && Check.ValidZipcode(uxZipcode.Text, out message))
            {
                return true;
            }
            MessageBox.Show(message);
            return false;
        }
    }
}
