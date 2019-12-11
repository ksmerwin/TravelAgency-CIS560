/*
	Creates a new restaurant
*/
CREATE OR ALTER PROCEDURE Restaurants.CreateRestaurant
	@Name NVARCHAR(120),
	@CityID INT,
	@RestaurantID INT OUTPUT
AS

INSERT Restaurants.Restaurant([Name], CityID)
VALUES(@Name, @CityID);

SET @RestaurantID = SCOPE_IDENTITY();
GO
