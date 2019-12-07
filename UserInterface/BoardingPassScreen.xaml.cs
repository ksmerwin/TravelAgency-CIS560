using DataAccess;
using DataModeling;
using DataModeling.Model;
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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for BoardingPassScreen.xaml
    /// </summary>
    public partial class BoardingPassScreen : Page
    {
        private int tripID;
        private string connectionString;
        public BoardingPassScreen()
        {
            InitializeComponent();
        }

        public BoardingPassScreen(string connectionString, int tripID, string city, string country, string region)
        {
            InitializeComponent();
            this.tripID = tripID;
            this.connectionString = connectionString;
            uxArrivalCity.Text = city;
            uxArrivalCountry.Text = country;
            uxArrivalRegion.Text = region;
        }

        /// <summary>
        /// Autofill the flight information given a valid flightID when user clicks "Autofill" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Autofill_Click(object sender, RoutedEventArgs args)
        {
            string message = "";
            if(Check.ValidPositiveInt("Flight ID", uxFlightID.Text, out message))
            {
                int flightID = int.Parse(uxFlightID.Text);

                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                Flight flight = executor.ExecuteReader(new RetrieveFlightInfoDelegate(flightID));

                if (flight == null)
                {
                    MessageBox.Show("Flight does not exist");
                }
                else
                {
                    City departurecity = executor.ExecuteReader(new LocationGetCityByCityIdDelegate(flight.CityDepartureID));
                    City arrivalcity = executor.ExecuteReader(new LocationGetCityByCityIdDelegate(flight.CityArrivalID));

                    uxAirlineName.Text = flight.AirlineName;
                    uxDepartureCity.Text = departurecity.CityName;
                    uxDepartureCountry.Text = departurecity.Country;
                    uxDepartureRegion.Text = departurecity.Region;
                    uxDepartureTime.Text = flight.DepartureTime.Hour + ":" + flight.DepartureTime.Minute;
                    uxDepartureDate.SelectedDate = new DateTime(flight.DepartureTime.Year, flight.DepartureTime.Month, flight.DepartureTime.Day, 0,0,0);
                    uxDepartureDate.DisplayDate = (DateTime)uxDepartureDate.SelectedDate;

                    uxArrivalCity.Text = arrivalcity.CityName;
                    uxArrivalCountry.Text = arrivalcity.Country;
                    uxArrivalRegion.Text = arrivalcity.Region;
                    uxArrivalTime.Text = flight.ArrivalTime.Hour + ":" + flight.ArrivalTime.Minute;
                    uxArrivalDate.SelectedDate = new DateTime(flight.ArrivalTime.Year, flight.ArrivalTime.Month, flight.ArrivalTime.Day, 0, 0, 0);
                    uxArrivalDate.DisplayDate = (DateTime)uxArrivalDate.SelectedDate;
                }
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// If valid inputs, adds a boarding pass using info when the user clicks "Add Boarding Pass" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddBoardingPass_Click(object sender, RoutedEventArgs args)
        {
            if(CheckValidInputs())
            {
                string airlineName = Check.FormatName(uxAirlineName.Text);
                float boardingPassPrice = float.Parse(uxBoardingPassPrice.Text);

                DateTime departureTime = new DateTime(((DateTime)uxDepartureDate.SelectedDate).Year, ((DateTime)uxDepartureDate.SelectedDate).Month,
                    ((DateTime)uxDepartureDate.SelectedDate).Day, int.Parse(uxDepartureTime.Text.Split(':')[0]),
                    int.Parse(uxDepartureTime.Text.Split(':')[1]), 0);
                string departureCity = Check.FormatName(uxDepartureCity.Text);
                string departureCountry = Check.FormatName(uxDepartureCountry.Text);
                string departureRegion = Check.FormatName(uxDepartureRegion.Text);

                DateTime arrivalTime = new DateTime(((DateTime)uxArrivalDate.SelectedDate).Year, ((DateTime)uxArrivalDate.SelectedDate).Month,
                    ((DateTime)uxArrivalDate.SelectedDate).Day, int.Parse(uxArrivalTime.Text.Split(':')[0]),
                    int.Parse(uxArrivalTime.Text.Split(':')[1]), 0);
                string arrivalCity = Check.FormatName(uxArrivalCity.Text);
                string arrivalCountry = Check.FormatName(uxArrivalCountry.Text);
                string arrivalRegion = Check.FormatName(uxArrivalRegion.Text);

                int cityDepartureID = 0;
                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                City departurecitysearch = executor.ExecuteReader(new LocationGetCityDelegate(departureCity, departureCountry, departureRegion));
                
                if (departurecitysearch == null)
                {
                    City newdeparturecity = executor.ExecuteNonQuery(new LocationCreateCityDelegate(departureCity, departureRegion, departureCountry));
                    cityDepartureID = newdeparturecity.CityID;
                }
                else
                {
                    cityDepartureID = departurecitysearch.CityID;
                }

                int cityArrivalID = 0;

                City arrivalcitysearch = executor.ExecuteReader(new LocationGetCityDelegate(arrivalCity, arrivalCountry, arrivalRegion));
                if (arrivalcitysearch == null)
                {
                    City newarrivalcity = executor.ExecuteNonQuery(new LocationCreateCityDelegate(arrivalCity, arrivalRegion, arrivalCountry));
     
                    cityArrivalID = newarrivalcity.CityID;
                }
                else
                {
                    cityArrivalID = arrivalcitysearch.CityID;
                }
                int flightID = 0;

                Flight flightsearch = executor.ExecuteReader(new GetFlightDelegate(airlineName, departureTime, cityDepartureID, arrivalTime, cityArrivalID));
                if (flightsearch == null)
                {
                    Flight flight = executor.ExecuteNonQuery(new CreateFlightDelegate(airlineName, departureTime, arrivalTime, cityDepartureID, cityArrivalID));
                    flightID = flight.FlightID;
                }
                else
                {
                    flightID = flightsearch.FlightID;
                }

                BoardingPass bp = executor.ExecuteNonQuery(new CreateBoardingPassDelegate(tripID, flightID, boardingPassPrice));

                MessageBox.Show("Boarding pass successfully added to flight " + flightID + " with airline " + airlineName);                
            }
        }

        public void Done_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new PlanTripScreen(connectionString, tripID, uxArrivalCountry.Text, uxArrivalRegion.Text, uxArrivalCity.Text));
        }

        /// <summary>
        /// Checks whether all valid inputs have been entered; if not, display appropriate message to user
        /// </summary>
        /// <returns>Whether all valid inputs or not</returns>
        private bool CheckValidInputs()
        {
            string message = "";
            if(Check.ValidName("Airline", uxAirlineName.Text, out message)
                && Check.ValidPositiveFloat("Boarding pass price", uxBoardingPassPrice.Text, out message)
                && Check.ValidTime("Departure Time", uxDepartureTime.Text, out message)
                && Check.ValidName("Departure City", uxDepartureCity.Text, out message)
                && Check.ValidName("Departure Country", uxDepartureCountry.Text, out message)
                && Check.ValidName("Departure Region", uxDepartureRegion.Text, out message)
                && Check.NonNull("Departure Date", uxDepartureDate.SelectedDate, out message)
                && Check.ValidTime("Arrival Time", uxArrivalTime.Text, out message)
                && Check.ValidName("Arrival City", uxArrivalCity.Text, out message)
                && Check.ValidName("Arrival Country", uxArrivalCountry.Text, out message)
                && Check.ValidName("Arrival Region", uxArrivalRegion.Text, out message)
                && Check.NonNull("Arrival Date", uxArrivalDate.SelectedDate, out message))
            {
                return true;
            }
            MessageBox.Show(message);
            return false;
        }
    }
}
