USE TravelAgency;
GO
CREATE OR ALTER PROCEDURE Agency.CreateReservation
	@ReservationID INT OUTPUT,
	@DateCreated DATETIMEOFFSET OUTPUT,
	@CarReservation BIT,
	@HotelReservation BIT,
	@BoardingPass BIT,
	@AttractionTicket BIT,
	@RestaurantReservation BIT,
	@TripID INT
AS
INSERT Agency.Reservations(CarReservation, HotelReservation, BoardingPass, AttractionTicket, RestaurantReservation, TripID)
VALUES(@CarReservation, @HotelReservation, @BoardingPass, @AttractionTicket, @RestaurantReservation, @TripID)
SET @ReservationID = SCOPE_IDENTITY()
SET @DateCreated = 
(SELECT R.DateCreated
FROM Agency.Reservations R
WHERE R.ReservationID = @ReservationID);
GO