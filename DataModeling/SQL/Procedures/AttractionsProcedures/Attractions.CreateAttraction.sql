/*
	Creates a new attraction
*/
CREATE OR ALTER PROCEDURE Attractions.CreateAttraction
	@Name NVARCHAR(120),
	@CityID INT,
	@AttractionID INT OUTPUT
AS

INSERT Attractions.Attraction([Name], CityID)
VALUES(@Name, @CityID);

SET @AttractionID = SCOPE_IDENTITY();
GO