CREATE OR ALTER PROCEDURE Airlines.CreateBoardingPass
	@ReservationID INT OUTPUT,
	@TripID INT,
	@FlightID INT,
	@Price FLOAT
AS
INSERT Agency.Reservations(BoardingPass, TripID)
VALUES(1, @TripID)
SET @ReservationID = SCOPE_IDENTITY();
INSERT Airlines.BoardingPass(ReservationID, Price, FlightID)
VALUES(@ReservationID, @Price, @FlightID)