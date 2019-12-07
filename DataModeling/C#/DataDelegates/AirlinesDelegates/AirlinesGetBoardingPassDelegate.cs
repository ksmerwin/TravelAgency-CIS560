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
    public class AirlinesGetBoardingPassDelegate : DataReaderDelegate<BoardingPass>
    {
        private readonly int reservationID;

        public AirlinesGetBoardingPassDelegate(int reservationID) : base("Airlines.GetBoardingPass")
        {
            this.reservationID = reservationID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ReservationID", reservationID);
        }

        public override BoardingPass Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new BoardingPass(reservationID, reader.GetInt32("FlightID"), reader.GetDouble("Price"));
        }
    }
}
