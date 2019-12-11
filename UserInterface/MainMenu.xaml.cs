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
    /// Main menu for travel agency
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor initializes database and server given a connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public MainMenu(string connectionString)
        {
            InitializeComponent();
            string[] temp = connectionString.Split(';');
            uxServer.Text = temp[0].Split('=')[1];
            uxDatabase.Text = temp[1].Split('=')[1];          
        }

        /// <summary>
        /// Open new trip setup page when user clicks "New Trip" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NewTrip_Click(object sender, RoutedEventArgs args)
        {
            if(GetConnectionString(out string connectionString))
            {
                NavigationService.Navigate(new TripSetupScreen(connectionString));
            }            
        }

        /// <summary>
        /// Open new search trip screen when user clicks "Search Trips" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SearchTrips_Click(object sender, RoutedEventArgs args)
        {
            if(GetConnectionString(out string connectionString))
            {
                NavigationService.Navigate(new SearchTripsScreen(connectionString));
            }            
        }

        /// <summary>
        /// Open trip statistics page when user clicks "Trip Statistics" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void TripStatistics_Click(object sender, RoutedEventArgs args)
        {
            if(GetConnectionString(out string connectionString))
            {
                NavigationService.Navigate(new TripStatisticsScreen(connectionString));
            }            
        }

        /// <summary>
        /// Gets the connection string using the server and database
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <returns>Whether the connection string was made</returns>
        private bool GetConnectionString(out string connectionString)
        {
            connectionString = "";
            string message = "";
            if(Check.NonNull("Server", uxServer.Text, out message)
                && Check.NonNull("Datebase", uxDatabase.Text, out message))
            {
                connectionString = "Data Source=" + uxServer.Text + ";Initial Catalog=" + uxDatabase.Text + ";Integrated Security=SSPI;";
                return true;
            }
            MessageBox.Show(message);
            return false;
        }
    }
}
