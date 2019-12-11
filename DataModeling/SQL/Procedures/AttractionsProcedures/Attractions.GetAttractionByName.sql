/*
	Gets an attraction given all info except its id
*/
USE TravelAgency;
GO
CREATE OR ALTER PROCEDURE Attractions.GetAttractionByName
	@Name NVARCHAR(120),
	@CityID INT
AS
SELECT A.AttractionID, A.[Name], A.CityID
FROM Attractions.Attraction A
WHERE @Name = A.[Name]
AND @CityID = A.CityID;