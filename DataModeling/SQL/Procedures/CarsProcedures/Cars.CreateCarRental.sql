/*
	Creates a new car rental agency
*/
CREATE OR ALTER PROCEDURE Cars.CreateCarRental
	@CarRentalID INT OUTPUT,
	@AgencyName NVARCHAR(120),
	@CityID INT
AS

INSERT Cars.CarRental(AgencyName, CityID)
VALUES (@AgencyName, @CityID)

SET @CarRentalID = SCOPE_IDENTITY();
GO