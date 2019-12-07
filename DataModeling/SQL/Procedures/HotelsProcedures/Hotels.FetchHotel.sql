CREATE OR ALTER PROCEDURE Hotels.FetchHotel
	@Name NVARCHAR(120),
	@CityID INT,
	@FullAddress NVARCHAR(200)
AS
SELECT H.HotelID, H.[Name], H.CityID, H.FullAddress
FROM Hotels.Hotel H
WHERE @Name = H.[Name] AND
@CityID = H.CityID AND
@FullAddress = H.FullAddress;
