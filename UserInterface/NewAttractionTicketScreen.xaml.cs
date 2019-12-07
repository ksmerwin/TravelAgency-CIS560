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
using DataAccess;
using DataModeling;
using DataModeling.Model;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for NewAttractionTicketScreen.xaml
    /// </summary>
    public partial class NewAttractionTicketScreen : Page
    {
        private int tripID;
        private string connectionString;

        public NewAttractionTicketScreen()
        {
            InitializeComponent();
        }

        public NewAttractionTicketScreen(string connectionString, int tripID, string city, string region, string country)
        {
            InitializeComponent();
            this.tripID = tripID;
            this.connectionString = connectionString;
            uxCity.Text = city;
            uxRegion.Text = region;
            uxCountry.Text = country;
        }

        /// <summary>
        /// Return to the plan trip screen when the user clicks "Done" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Done_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new PlanTripScreen(connectionString, tripID, uxCountry.Text, uxRegion.Text, uxCity.Text));
        }

        /// <summary>
        /// Autofills some of the information given an attractionID when the user clicks "Autofill" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Autofill_Click(object sender, RoutedEventArgs args)
        {
            string message = "";
            if (Check.ValidPositiveInt("Attraction ID", uxAttractionID.Text, out message))
            {
                int attractionID = int.Parse(uxAttractionID.Text);

                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                if (executor.ExecuteReader(new GetAttractionDataDelegate(attractionID)) == null) 
                {
                    MessageBox.Show("Attraction does not yet exist");

                }
                else
                {

                    Attraction attraction = executor.ExecuteReader(new GetAttractionDataDelegate(attractionID));
                    City city = executor.ExecuteReader(new LocationGetCityByCityIdDelegate(attraction.CityID));

                    uxAttractionName.Text = attraction.Name; 
                    uxCity.Text = city.CityName; 
                    uxCountry.Text = city.Country;
                    uxRegion.Text = city.Region; 
                }
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// If valid inputs, make new attraction ticket when the user clicks "Add Ticket" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddTicket_Click(object sender, RoutedEventArgs args)
        {
            if (CheckValidInputs())
            {
                string attractionName = Check.FormatName(uxAttractionName.Text);
                float ticketPrice = float.Parse(uxTicketPrice.Text);
                DateTime ticketDate = (DateTime)uxDate.SelectedDate;
                
                string country = Check.FormatName(uxCountry.Text);
                string region = Check.FormatName(uxRegion.Text);
                string cityName = Check.FormatName(uxCity.Text);

                int cityID = 0;

                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);
                City city = executor.ExecuteReader(new LocationGetCityDelegate(country, region, cityName));
                if (city == null)
                {
                    city = executor.ExecuteNonQuery(new LocationCreateCityDelegate(cityName, region: region, country));
                    cityID = city.CityID;
                }
                else
                {
                    cityID = city.CityID;
                }

                int attractionID = 0;
                Attraction attraction = executor.ExecuteReader(new GetAttractionDataDelegate(attractionID));

                if (attraction == null)
                {
                    attraction = executor.ExecuteNonQuery(new CreateAttractionDelegate(attractionName, cityID));
                    attractionID = attraction.AttractionID;
                }
                else
                {
                    attractionID = attraction.AttractionID;
                }           

                AttractionTicket at = executor.ExecuteNonQuery(new CreateAttractionTicketDelegate(tripID, attractionID, ticketDate, ticketPrice));

                MessageBox.Show("Attraction ticket successfully added for attraction " + attractionName);
            }
        }

        /// <summary>
        /// Checks that all valid inputs have been entered; if not, display appropriate message to user
        /// </summary>
        /// <returns>Whether all valid inputs</returns>
        private bool CheckValidInputs()
        {
            string message = "";
            if (Check.ValidName("Attraction name", uxAttractionName.Text, out message)
                && Check.ValidPositiveFloat("Ticket price", uxTicketPrice.Text, out message)
                && Check.NonNull("Ticket date", uxDate.SelectedDate, out message)
                && Check.ValidName("Country", uxCountry.Text, out message)
                && Check.ValidName("Region", uxRegion.Text, out message)
                && Check.ValidName("City", uxCity.Text, out message))
            {
                return true;
            }
            MessageBox.Show(message);
            return false;
        }
    }
}
