CREATE OR ALTER PROCEDURE Agency.GetReservations
	@TripID INT
AS
SELECT R.ReservationID, R.DateCreated, 
R.CarReservation, R.HotelReservation, R.BoardingPass, R.AttractionTicket, R.RestaurantReservation,
R.TripID
FROM Agency.Reservations R
WHERE R.IsDeleted = 0 AND
@TripID = R.TripID;
GO