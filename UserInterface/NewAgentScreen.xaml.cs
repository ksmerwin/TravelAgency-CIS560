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
    /// Interaction logic for NewAgentScreen.xaml
    /// </summary>
    public partial class NewAgentScreen : Page
    {
        private string connectionString;

        public NewAgentScreen(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Add agent to the database if valid entries when user clicks "Add Agent" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddAgent_Click(object sender, RoutedEventArgs args)
        {
            if(CheckValidInputs())
            {
                // CONNECT 
                // Create New Agent
                int agentID = 0;
                string fullName = Check.FormatName(uxAgentFirstName.Text) + " " + Check.FormatName(uxAgentLastName.Text);
                float salary = float.Parse(uxSalary.Text);

                SqlCommandExecutor executor = new SqlCommandExecutor(connectionString);
                AgencyCreateAgentDelegate createsAgent = new AgencyCreateAgentDelegate(fullName, salary);
                Agent agent = executor.ExecuteNonQuery(createsAgent);
                agentID = agent.AgentID;
                

                MessageBox.Show("Agent " + fullName + " successfully added. Agent ID = " + agentID);
            }
        }

        public void Done_Click(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new TripSetupScreen(connectionString));
        }

        /// <summary>
        /// Checks that there are valid inputs; if not, displays appropriate message
        /// </summary>
        /// <returns>Whether there are valid inputs</returns>
        public bool CheckValidInputs()
        {
            string message = "";
            if(Check.ValidSingleName("First name", uxAgentFirstName.Text, out message) && Check.ValidSingleName("Last name", uxAgentLastName.Text, out message)
                && Check.ValidPositiveFloat("Salary", uxSalary.Text, out message))
            {
                return true;
            }
            MessageBox.Show(message);
            return false;
        }        
    }
}
