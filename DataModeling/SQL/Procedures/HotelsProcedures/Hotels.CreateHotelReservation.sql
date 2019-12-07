CREATE OR ALTER PROCEDURE Hotels.CreateHotelReservation
	@ReservationID INT OUTPUT,
	@HotelID INT,
	@CheckinDate DATE,
	@Price FLOAT,
	@TripID INT
AS
INSERT Agency.Reservations(HotelReservation, TripID)
VALUES(1, @TripID)
SET @ReservationID = SCOPE_IDENTITY();
INSERT Hotels.HotelReservation(ReservationID, HotelID, CheckInDate, Price)
	VALUES(@ReservationID, @HotelID, @CheckinDate, @Price);
GO

