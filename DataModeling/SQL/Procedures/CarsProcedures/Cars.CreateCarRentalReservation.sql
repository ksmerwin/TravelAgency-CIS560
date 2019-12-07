CREATE OR ALTER PROCEDURE Cars.CreateCarRentalReservation
	@ReservationID INT OUTPUT,
	@TripID INT,
	@CarRentalID INT,
	@RentalDate DATE,
	@Model NVARCHAR(120),
	@Price FLOAT
AS
INSERT Agency.Reservations(CarReservation, TripID)
VALUES(1, @TripID)

SET @ReservationID = SCOPE_IDENTITY();

INSERT Cars.CarRentalReservation(ReservationID, CarRentalID, RentalDate, Model, Price)
VALUES(@ReservationID, @CarRentalID, @RentalDate, @Model, @Price);
GO
