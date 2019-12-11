/*
	Gets a restuarant given its id
*/
CREATE OR ALTER PROCEDURE Restaurants.GetRestaurant
	@RestaurantID INT

AS

SELECT RestaurantID, [Name], CityID
FROM Restaurants.Restaurant
WHERE RestaurantID = @RestaurantID;
GO