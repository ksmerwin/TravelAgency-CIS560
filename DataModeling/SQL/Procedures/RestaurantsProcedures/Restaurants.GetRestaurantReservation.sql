/*
	Gets restaurant reservation given its id
*/
CREATE OR ALTER PROCEDURE Restaurants.GetRestaurantReservation
	@ReservationID INT
AS

SELECT ReservationID, ReservationDate, RestaurantID
FROM Restaurants.RestaurantReservation
WHERE ReservationID = @ReservationID;
GO