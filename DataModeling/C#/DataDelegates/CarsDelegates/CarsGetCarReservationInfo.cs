using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class CarsGetCarReservationInfo : DataReaderDelegate<CarRentalReservation>
    {
        private readonly int reservationID;

        public CarsGetCarReservationInfo(int ReservationID)
           : base("Cars.GetCarReservationInfo")
        {
            this.reservationID = ReservationID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ReservationID", reservationID);
        }

        public override CarRentalReservation Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(reservationID.ToString());

            return new CarRentalReservation(reader.GetInt32("ReservationID"),
               reader.GetInt32("CarRentalID"),
               reader.GetDateTime("RentalDate"),
               reader.GetString("Model"),
               reader.GetDouble("Price")
               );
        }
    }
}