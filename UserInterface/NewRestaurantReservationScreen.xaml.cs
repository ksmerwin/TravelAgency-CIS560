using DataAccess;
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
using DataModeling;
using DataModeling.Model;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for NewRestaurantReservationScreen.xaml
    /// </summary>
    public partial class NewRestaurantReservationScreen : Page
    {
        private int tripID;
        private string connectionString;
        public NewRestaurantReservationScreen()
        {
            InitializeComponent();
        }

        public NewRestaurantReservationScreen(string connectionString, int tripID, string city, string region, string country)
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
        /// Autofills restaurant information with restaurant ID when user clicks "Autofill" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Autofill_Click(object sender, RoutedEventArgs args)
        {
            string message = "";
            if(Check.ValidPositiveInt("Restaurant ID", uxRestaurantID.Text, out message))
            {
                int restaurantID = int.Parse(uxRestaurantID.Text);

                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                Restaurant restaurant = executor.ExecuteReader(new RestaurantsGetRestaurantDelegate(restaurantID));

                if (restaurant == null)
                {
                      MessageBox.Show("Restaurant does not already exist");

                }
                else
                {
                    City city = executor.ExecuteReader(new LocationGetCityByCityIdDelegate(restaurantID));
                    uxRestaurantName.Text = restaurant.Name;
                    uxCity.Text = city.CityName;
                    uxRegion.Text = city.Region;
                    uxCountry.Text = city.Country;
                }
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// If valid inputs, create a new restaurant reservation when the user clicks "Add Reservation" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddReservation_Click(object sender, RoutedEventArgs args)
        {
            if(CheckValidInputs())
            {
                string restaurantName = Check.FormatName(uxRestaurantName.Text);
                DateTime reservationTime = new DateTime(((DateTime)uxReservationDate.SelectedDate).Year,
                    ((DateTime)uxReservationDate.SelectedDate).Month, ((DateTime)uxReservationDate.SelectedDate).Day,
                    int.Parse(uxReservationTime.Text.Split(':')[0]), int.Parse(uxReservationTime.Text.Split(':')[1]), 0);

                string cityName = Check.FormatName(uxCity.Text);
                string country = Check.FormatName(uxCountry.Text);
                string region = Check.FormatName(uxRegion.Text);
                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                int cityID = 0;
                City city = executor.ExecuteReader(new LocationGetCityDelegate(cityName, country, region));
                if(city == null)
                {
                    city = executor.ExecuteNonQuery(new LocationCreateCityDelegate(cityName, region, country));
                }
                cityID = city.CityID;

                int restaurantID = 0;

                Restaurant restaurant = executor.ExecuteReader(new RestaurantGetResturantByNameDelegate(restaurantName, cityID));

                if(restaurant == null)
                {
                    restaurant = executor.ExecuteNonQuery(new RestaurantCreateRestaurantDelegate(cityID, cityName));
                }
                restaurantID = restaurant.RestaurantID;

                RestaurantReservation restaurantReservation = 
                    executor.ExecuteNonQuery(new RestaurantsCreateRestaurantReservationDelegate(tripID, restaurantID, reservationTime));

                MessageBox.Show("Reservation successfully added for " + restaurantName);
            }
        }

        /// <summary>
        /// Check that all entries are valid; if not, display appropriate message to user
        /// </summary>
        /// <returns>Whether all entries are valid</returns>
        private bool CheckValidInputs()
        {
            string message = "";
            if (Check.ValidName("Restaurant name", uxRestaurantName.Text, out message)
                && Check.ValidTime("Reservation time", uxReservationTime.Text, out message)
                && Check.NonNull("Reservation date", uxReservationDate.SelectedDate, out message)
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
