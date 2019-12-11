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
    /// Interaction logic for PlanTripScreen.xaml
    /// </summary>
    public partial class PlanTripScreen : Page
    {
        private string connectionString;
        //private List<Reservation> reservations

        private int tripID;
        private string country = "";
        private string region = "";
        private string cityName = "";

        public PlanTripScreen()
        {
            InitializeComponent();
        }

        public PlanTripScreen(string connectionString, int tripID)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.tripID = tripID;
            LoadAllReservations();
        }

        public PlanTripScreen(string connectionString, int tripID, string country, string region, string cityName)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.tripID = tripID;
            this.country = country;
            this.region = region;
            this.cityName = cityName;
            LoadAllReservations();
        }

        /// <summary>
        /// Return to main menu when user clicks "Done" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Done_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new MainMenu(connectionString));
        }

        /// <summary>
        /// Navigate to new hotel reservation page when user clicks "New Hotel Reservation" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NewHotelReservation_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new HotelReservationScreen(connectionString, tripID, country, region, cityName));
        }

        /// <summary>
        /// Navigate to new boarding pass page when user clicks "New Boarding Pass" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NewBoardingPass_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new BoardingPassScreen(connectionString, tripID, cityName, country, region));
        }

        /// <summary>
        /// Navigate to new attraction ticket page when user clicks "New Attraction Ticket" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NewAttractionTicket_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new NewAttractionTicketScreen(connectionString, tripID, cityName, region, country));
        }

        /// <summary>
        /// Navigate to new restaurant reservation page when user clicks "New Restaurant Reservation" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NewRestaurantReservation_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new NewRestaurantReservationScreen(connectionString, tripID, cityName, region, country));
        }

        /// <summary>
        /// Navigate to new car rental reservation page when user clicks "New Car Rental Reservation" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NewCarRentalReservation_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new NewCarRentalReservationScreen(connectionString, tripID, cityName, region, country));
        }

        /// <summary>
        /// Deletes the selected reservation from the trip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void DeleteSelected_Click(object sender, RoutedEventArgs args)
        {            
            if(uxReservations.SelectedItem != null)
            {
                if(uxReservations.SelectedItem is TextBlock t)
                {
                    int reservationID = int.Parse(t.Text.Split('\t')[1].Split(',')[0].Trim());

                    SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);
                    executor.ExecuteNonQuery(new AgencyDeleteReservationDelegate(reservationID));

                    uxReservations.Items.Remove(uxReservations.SelectedItem);
                    MessageBox.Show("Reservation " + reservationID + " was successfully deleted.");
                }
                else
                {
                    MessageBox.Show("Unable to access selected reserveration");
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete");
            }
        }

        /// <summary>
        /// Loads all the reservations into the reservation list
        /// </summary>
        private void LoadAllReservations()
        {
            uxReservations.Items.Clear();

            SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);
            List<Reservation> reservations = (List<Reservation>)executor.ExecuteReader(new AgencyGetReservationsDelegate(tripID));
            if(reservations.Count != 0)
            {
                foreach(Reservation reservation in reservations)
                {
                    IReservation r;
                    if(reservation.CarReservation)
                    {
                        r = executor.ExecuteReader(new CarsGetCarReservationInfo(reservation.ReservationID));
                    }
                    else if(reservation.HotelReservation)
                    {
                        r = executor.ExecuteReader(new HotelsGetHotelReservationDelegate(reservation.ReservationID));
                    }
                    else if(reservation.BoardingPass)
                    {
                        r = executor.ExecuteReader(new AirlinesGetBoardingPassDelegate(reservation.ReservationID));
                    }
                    else if(reservation.AttractionTicket)
                    {
                        r = executor.ExecuteReader(new GetAttractionTicketDelegate(reservation.ReservationID));
                    }
                    else
                    {
                        r = executor.ExecuteReader(new RestaurantsGetRestaurantReservationDelegate(reservation.ReservationID));
                    }
                    TextBlock t = new TextBlock();
                    t.Text = r.ReservationInfo();
                    uxReservations.Items.Add(t);
                }
            }          
            RefreshReservationList();
        }

        /// <summary>
        /// Refreshes the reservation list
        /// </summary>
        private void RefreshReservationList()
        {
            ListBox l = uxReservations;
            uxReservations = l;
        }
    }
}
