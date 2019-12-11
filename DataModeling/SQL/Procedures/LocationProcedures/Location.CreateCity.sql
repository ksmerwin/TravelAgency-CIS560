/*
	Creates a new city
*/
CREATE OR ALTER PROCEDURE [Location].CreateCity
	@CityID INT OUTPUT,
	@CityName NVARCHAR(120),
	@Region NVARCHAR(120),
	@Country NVARCHAR(120)
AS

INSERT [Location].Cities(CityName, Region, Country)
	VALUES(@CityName, @Region, @Country)

SET @CityID = SCOPE_IDENTITY();
GO