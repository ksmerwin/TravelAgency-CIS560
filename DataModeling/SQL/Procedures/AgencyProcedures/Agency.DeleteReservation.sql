/*
	Sets the isDeleted column to 1 (true) for a particular reservation
*/
CREATE OR ALTER PROCEDURE Agency.DeleteReservation
	@ReservationID INT
AS
UPDATE Agency.Reservations
SET IsDeleted = 1
WHERE @ReservationID = ReservationID;
GO