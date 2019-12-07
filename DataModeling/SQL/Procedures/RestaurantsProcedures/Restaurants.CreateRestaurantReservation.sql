CREATE OR ALTER PROCEDURE Restaurants.CreateRestaurantReservation
 @ReservationID INT OUTPUT,
 @TripID INT,
 @ReservationDate DATE, 
 @RestaurantID INT
AS

INSERT Agency.Reservations(RestaurantReservation, TripID)
VALUES(1, @TripID)

SET @ReservationID = SCOPE_IDENTITY();

INSERT Restaurants.RestaurantReservation(ReservationID, ReservationDate, RestaurantID)
VALUES (@ReservationID, @ReservationDate, @RestaurantID);

GO
