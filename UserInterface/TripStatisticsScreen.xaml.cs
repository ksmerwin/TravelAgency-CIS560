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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for TripStatisticsScreen.xaml
    /// </summary>
    public partial class TripStatisticsScreen : Page
    {
        private string connectionString;

        public TripStatisticsScreen()
        {
            InitializeComponent();
        }

        public TripStatisticsScreen(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Return to the main menu when the user clicks "Main Menu" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MainMenu_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Get a monthly summary report of sales and the avererage customer per agent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MonthlySalesReport_Click(object sender, RoutedEventArgs args)
        {

            uxReportList.Items.Clear();
            SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

            List<string> monthlyDetail = (List<string>)executor.ExecuteReader(new AgencyDetailByMonthDelegate());

            //Set label for columns
            uxReportListLabel.Content = $"{Check.Format(" Year, Month",20,true)}{Check.Format("Trip Count",15,true)}" +
                $"{Check.Format("Ave. Customers Per Agent",40,true)}{Check.Format("Total Sales",20,true)}";

            if (monthlyDetail.Count > 0)
            {
                //Get each row and format into columns
                foreach (string row in monthlyDetail)
                {
                    string[] splitRow = row.Split(',');
                    TextBlock t = new TextBlock();
                    t.Text = $"  {Check.Format(splitRow[0],4,true)}, {Check.Format(splitRow[1],18,true)}{Check.Format(splitRow[2],28,true)}" +
                        $"{Check.Format(splitRow[3],35,true)}{Check.Format(splitRow[4],20,true)}";

                    uxReportList.Items.Add(t);
                }
            }
        }

        /// <summary>
        /// Get the top 10 most visited attractions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void TopTenAttractions_Click(object sender, RoutedEventArgs args)
        {
            uxReportList.Items.Clear();
            SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

            List<string> topTenAttractions = (List<string>)executor.ExecuteReader(new AgencyTopTenAttractionsDelegate());

            //Set label for columns
            uxReportListLabel.Content = $"{Check.Format("Attraction",20,false)}{Check.Format("Number of Customers",30,false)}" +
                $"{Check.Format("City, Country",20,false)}{Check.Format("Ticket Price",20,false)}";

            if(topTenAttractions.Count > 0)
            {
                //Add each row and format into columns
                foreach(string row in topTenAttractions)
                {
                    string[] splitRow = row.Split('-');
                    TextBlock t = new TextBlock();
                    t.Text = $"{Check.Format(splitRow[0],6,false)} {Check.Format(splitRow[1],40,true)}" +
                        $"{Check.Format(splitRow[2],16,true)}{Check.Format(splitRow[3],32,true)}" +
                        $"{Check.Format(splitRow[4],20,true)}";
                    uxReportList.Items.Add(t);
                }
            }
        }

        /// <summary>
        /// Get an age group report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AgeReport_Click(object sender, RoutedEventArgs args)
        {
            uxReportList.Items.Clear();
            SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

            List<string> ageGroups = (List<string>)executor.ExecuteReader(new AgencyAgeReportDelegate());

            //Set label for columns
            uxReportListLabel.Content = $"{Check.Format("Age Group", 12, true)}{Check.Format("Customers", 10, true)}" +
                $"{Check.Format("Ave. Budget", 13, true)}{Check.Format("Low. Budget",13,true)}" +
                $"{Check.Format("High. Budget",13,true)}{Check.Format("Ave. Age",10,true)}" +
                $"{Check.Format("Trip Count",10,true)}";

            if(ageGroups.Count > 0)
            {
                //Add each row and format into columns
                foreach(string row in ageGroups)
                {
                    string[] splitRow = row.Split(',');
                    TextBlock t = new TextBlock();
                    t.Text = $"{Check.Format(splitRow[0], 17, true)}{Check.Format(splitRow[1], 10, true)}" +
                        $"{Check.Format(splitRow[2], 15, true)}{Check.Format(splitRow[3],15,true)}" +
                        $"{Check.Format(splitRow[4],15,true)}{Check.Format(splitRow[5],12,true)}" +
                        $"{Check.Format(splitRow[6],10,true)}";

                    uxReportList.Items.Add(t);
                }
            }
        }

        /// <summary>
        /// Get the cheapest amenities for each city within the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void CheaperOptions_Click(object sender, RoutedEventArgs args)
        {
            uxReportList.Items.Clear();
            SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);

            List<string> cheaperOptions = (List<string>)executor.ExecuteReader(new AgencyCheapestOptionsDelegate());

            //Set label for columns
            uxReportListLabel.Content = $"{Check.Format("City, Country", 35, true)}{Check.Format("Cheapest Hotel",30,true)}" +
                $"{Check.Format("Cheapest Attraction",35,true)}";

            if (cheaperOptions.Count > 0)
            {
                //Add each row and format into columns
                foreach(string row in cheaperOptions)
                {
                    string[] splitRow = row.Split('-');
                    TextBlock t = new TextBlock();
                    t.Text = $"{Check.Format(splitRow[0], 35, true)}{Check.Format(splitRow[1],35,true)}" +
                        $"{Check.Format(splitRow[2],35,true)}";

                    uxReportList.Items.Add(t);
                }
            }
        }
    }
}
