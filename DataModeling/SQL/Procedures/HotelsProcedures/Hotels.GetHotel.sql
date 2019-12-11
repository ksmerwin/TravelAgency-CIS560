/*
	Gets a hotel given its id
*/
CREATE OR ALTER PROCEDURE Hotels.GetHotel
	@HotelID INT
AS

SELECT HO.[Name], HO.CityID, HO.FullAddress
FROM Hotels.Hotel HO
WHERE HO.HotelID = @HotelID
GO