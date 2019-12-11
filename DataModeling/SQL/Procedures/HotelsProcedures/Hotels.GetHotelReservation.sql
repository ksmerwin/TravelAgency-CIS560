/*
	Gets a hotel reservation given its id
*/
CREATE OR ALTER PROCEDURE Hotels.GetHotelReservation
	@ReservationID INT
AS

SELECT HR.HotelID, HR.CheckInDate, HR.Price
	FROM Hotels.HotelReservation HR
WHERE HR.ReservationID = @ReservationID
GO