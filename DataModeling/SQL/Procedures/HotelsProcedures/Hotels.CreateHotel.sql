/*
	Creates a new hotel
*/
CREATE OR ALTER PROCEDURE Hotels.CreateHotel
	@HotelID INT OUTPUT,
	@Name NVARCHAR(120),
	@CityID INT,
	@FullAddress NVARCHAR(200)
AS

INSERT Hotels.Hotel(Name, CityID, FullAddress)
	VALUES(@Name, @CityID, @FullAddress)

SET @HotelID = SCOPE_IDENTITY();
GO