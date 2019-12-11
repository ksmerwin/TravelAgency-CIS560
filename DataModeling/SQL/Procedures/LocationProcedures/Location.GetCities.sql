/*
	Gets a city given its id
*/
CREATE OR ALTER PROCEDURE Location.GetCities
	@CityID INT
AS

SELECT C.CityName, C.Region, C.Country
FROM [Location].Cities C
WHERE C.CityID = @CityID
GO