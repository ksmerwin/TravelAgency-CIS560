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
    /// Interaction logic for NewCarRentalReservationScreen.xaml
    /// </summary>
    public partial class NewCarRentalReservationScreen : Page
    {
        private int tripID;
        private string connectionString;

        public NewCarRentalReservationScreen()
        {
            InitializeComponent();
        }

        public NewCarRentalReservationScreen(string connectionString, int tripID, string city, string region, string country)
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
        /// Autofills the car rental information for car rental id when the user clicks "Autofill" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Autofill_Click(object sender, RoutedEventArgs args)
        {
            string message = "";
            if(Check.ValidPositiveInt("Car Rental ID", uxCarRentalID.Text, out message))
            {
                int carRentalID = int.Parse(uxCarRentalID.Text);
                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                CarRental agency = executor.ExecuteReader(new CarsGetAgencyByIDDelegate(carRentalID));
                City city = executor.ExecuteReader(new LocationGetCityByCityIdDelegate(agency.CityID));
                uxCarRentalAgencyName.Text = agency.AgencyName;
                uxCity.Text = city.CityName;
                uxCountry.Text = city.Country;
                uxRegion.Text = city.Region;
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// If valid inputs, create new car rental reservation when the user clicks "Add Reservation" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddReservation_Click(object sender, RoutedEventArgs args)
        {
            if(CheckValidInputs())
            {
                string carAgencyName = Check.FormatName(uxCarRentalAgencyName.Text);
                string carModel = Check.FormatName(uxCarModel.Text);
                float rentalPrice = float.Parse(uxRentalPrice.Text);
                DateTime rentalDate = (DateTime)uxRentalDate.SelectedDate;

                string cityName = Check.FormatName(uxCity.Text);
                string country = Check.FormatName(uxCountry.Text);
                string region = Check.FormatName(uxRegion.Text);

                int cityID = 0;
                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);
                City city = executor.ExecuteReader(new LocationGetCityDelegate(cityName, country, region));

                if (city == null)
                {
                     city = executor.ExecuteNonQuery(new LocationCreateCityDelegate(cityName, region, country));
                    cityID = city.CityID;
                }
                else
                {
                    cityID = city.CityID;
                }
                int carRentalID = 0;

                CarRental agency = executor.ExecuteReader(new CarsGetAgencyByNameDelegate(carAgencyName, cityID));
                if(agency == null)
                {
                    agency = executor.ExecuteNonQuery(new CarsCreateCarRentalDelegate(carAgencyName, cityID));
                    carRentalID = agency.CarRentalID;
                }
                else
                {
                    carRentalID = agency.CarRentalID;
                }

                CarRentalReservation carRentalReservation = executor.ExecuteNonQuery(new CarsCreateCarRentalReservationDelegate
                                                                    (tripID, carRentalID, rentalDate, carModel, rentalPrice));

                MessageBox.Show("Car successfully reserved with agency " + carAgencyName);
            }
        }

        /// <summary>
        /// Check that all entries are valid; if not, display appropriate message to user
        /// </summary>
        /// <returns>Whether all entries are valid</returns>
        private bool CheckValidInputs()
        {
            string message = "";
            if (Check.ValidName("Car Rental Agency Name", uxCarRentalAgencyName.Text, out message)
                && Check.NonNull("Model of Car", uxCarModel.Text, out message)
                && Check.ValidPositiveFloat("Rental price", uxRentalPrice.Text, out message)
                && Check.NonNull("Rental date", uxRentalDate.SelectedDate, out message)
                && Check.ValidName("City", uxCity.Text, out message)
                && Check.ValidName("Country", uxCountry.Text, out message)
                && Check.ValidName("Region", uxRegion.Text, out message))
            {
                return true;
            }
            MessageBox.Show(message);
            return false;
        }
    }
}
