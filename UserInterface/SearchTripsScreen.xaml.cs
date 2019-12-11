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
    /// Interaction logic for SearchTripsScreen.xaml
    /// </summary>
    public partial class SearchTripsScreen : Page
    {
        //private List<Trip> trips = new List<Trip>();
        private string connectionString;

        public SearchTripsScreen(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            LoadAllTrips();
            uxListLabel.Text = Check.Format("Trip", 12, true) + Check.Format("Customer",26,true) + 
                Check.Format("Agent", 20, true) + Check.Format("Date Created", 30, true);
        }

        /// <summary>
        /// Returns to the main menu when the user clicks "Main Menu" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MainMenu_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Reloads all trips into the list of trips and it throws out any for the respective filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Search_Click(object sender, RoutedEventArgs args)
        {
            uxTrips.Items.Clear();
            LoadAllTrips();

            //Check trip id filter
            if(uxTripID.Text != "")
            {
                string message = "";
                if(Check.ValidPositiveInt("Trip ID", uxTripID.Text, out message))
                {
                    FilterByMinTripID(int.Parse(uxTripID.Text));
                }
                else
                {
                    MessageBox.Show("Can't filter by trip ID. " + message);
                }
            }

            //Check if agent id filter
            if(uxAgentID.Text != "")
            {
                string message = "";
                if (Check.ValidPositiveInt("Agent ID", uxAgentID.Text, out message))
                {
                    FilterByAgentID(int.Parse(uxAgentID.Text));
                }
                else
                {
                    MessageBox.Show("Can't filter by Agent ID. " + message);
                }
            }

            //Check if customer filter
            if (uxCustomerName.Text != "")
            {
                FilterByCustomerName(Check.FormatName(uxCustomerName.Text));
            }
        }

        /// <summary>
        /// Opens a new plan trip screen to update the selected trip when user clicks "Update Trip" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void UpdateTrip_Click(object sender, RoutedEventArgs args)
        {
            if (uxTrips.SelectedItem != null)
            {

                if (uxTrips.SelectedItem is TextBlock)
                {
                    TextBlock t = (TextBlock)uxTrips.SelectedItem;
                    int tripID = int.Parse(t.Text.Split(' ')[0].Trim());

                    NavigationService.Navigate(new PlanTripScreen(connectionString, tripID));
                }
                else
                {
                    MessageBox.Show("Can't access selected item");
                }
            }
            else
            {
                MessageBox.Show("Please select a trip to update");
            }
        }

        /// <summary>
        /// Deletes the selected trip when the user clicks "Delete Trip" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void DeleteTrip_Click(object sender, RoutedEventArgs args)
        {
            if(uxTrips.SelectedItem != null)
            { 

                if(uxTrips.SelectedItem is TextBlock t)
                {                    
                    int tripID;                  
                    tripID = int.Parse(t.Text.Split(' ')[0].Trim());
                    
                    SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

                    //Find trip
                    Trip trip = executor.ExecuteReader(new AgencyFetchTripDelegate(tripID));
                    //Set isDeleted value for trip to 1
                    executor.ExecuteNonQuery(new AgencySaveTripDelegate(trip.TripID, trip.CustomerID, 1, trip.DateCreated, trip.AgentID));

                    uxTrips.Items.Remove(uxTrips.SelectedItem);
                    RefreshTripList();
                    MessageBox.Show("Trip " + tripID + " has been removed");
                }
                else
                {
                    MessageBox.Show("Can't access selected item");
                }
            }
            else
            {
                MessageBox.Show("Please select a trip to delete");
            }
        }

        /// <summary>
        /// Loads all trips into the trip list
        /// </summary>
        private void LoadAllTrips()
        {
            // Format for list
            // TripID, CustomerName, CustomerID, AgentName, AgentID, DateCreated
            SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

            List<Trip> trips = (List<Trip>)executor.ExecuteReader(new AgencyGetTripsDelegate());
            if(trips.Count != 0)
            {
                foreach(Trip trip in trips)
                {
                    Customer customer = executor.ExecuteReader(new AgencyGetCustomerDelegate(trip.CustomerID));
                    Agent agent = executor.ExecuteReader(new AgencyGetAgentDelegate(trip.AgentID));
                    TextBlock t = new TextBlock();
                    t.Text = $"{Check.Format(trip.TripID, 8, true)}{Check.Format(customer.CustomerID, 6, false)} - " +
                        $"{Check.Format(customer.Name, 20, true)}" +
                        $"{Check.Format(agent.AgentID, 8, false)} - {Check.Format(agent.Name, 20, true)}{Check.Format(trip.DateCreated, 30, true)}";
                    uxTrips.Items.Add(t);
                }
            }
            RefreshTripList();
        }

        /// <summary>
        /// Filters out all trips less than the specific trip ID
        /// </summary>
        /// <param name="tripID">The trip ID to filter on</param>
        private void FilterByMinTripID(int tripID)
        {
            for(int i = 0; i < uxTrips.Items.Count; i++)
            {
                object item = uxTrips.Items[i];
                if(item is TextBlock t)
                {
                    int compareTripID = int.Parse(t.Text.Split(' ')[0].Trim());
                    if (compareTripID < tripID)
                    {
                        uxTrips.Items.Remove(item);
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// Filters the existing trips to only the specific agent ID
        /// </summary>
        /// <param name="agentID">The agent ID to filter on</param>
        private void FilterByAgentID(int agentID)
        {
            for(int i = 0; i < uxTrips.Items.Count; i++)
            {
                object item = uxTrips.Items[i];
                if (item is TextBlock t)
                {
                    int compareAgentID = Check.GetNumberAtEndOfString(t.Text.Split('-')[1]);
                    if (compareAgentID != agentID)
                    {
                        uxTrips.Items.Remove(item);
                        i--;
                    }
                }
            }
            RefreshTripList();
        }

        /// <summary>
        /// Filters the existing trips to only the specific customer name
        /// </summary>
        /// <param name="customerName">the customer name to filter on</param>
        private void FilterByCustomerName(string customerName)
        {
            for (int i = 0; i < uxTrips.Items.Count; i++)
            {
                object item = uxTrips.Items[i];
                if (item is TextBlock t)
                {
                    if (!t.Text.Split('-')[1].Trim().Contains(Check.FormatName(customerName)))
                    {
                        uxTrips.Items.Remove(item);
                        i--;
                    }
                }
            }
            RefreshTripList();
        }

        /// <summary>
        /// Refresh the trip list
        /// </summary>
        private void RefreshTripList()
        {
            ListBox l = uxTrips;
            uxTrips = l;
        }
    }
}
