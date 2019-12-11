/*
	Gets the car rental reservation associated with the reservation ID
*/
CREATE OR ALTER PROCEDURE Cars.GetCarReservationInfo
	@ReservationID INT
AS

SELECT C.ReservationID, C.CarRentalID, C.RentalDate, C.Model, C.Price
FROM Cars.CarRentalReservation C 
WHERE @ReservationID = C.ReservationID;
GO