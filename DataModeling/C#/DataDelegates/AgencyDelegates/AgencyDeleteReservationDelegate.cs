using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModeling;
using DataModeling.Model;

namespace DataModeling
{
    public class AgencyDeleteReservationDelegate : DataDelegate
    {
        private readonly int reservationID;

        public AgencyDeleteReservationDelegate(int reservationID) : base("Agency.DeleteReservation")
        {
            this.reservationID = reservationID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ReservationID", reservationID);
        }
    }
}
