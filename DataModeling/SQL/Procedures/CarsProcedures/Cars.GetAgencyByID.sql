CREATE OR ALTER PROCEDURE Cars.GetAgencyByID
	@CarRentalID INT
AS

SELECT  CC.CarRentalID, CC.AgencyName, CC.CityID
FROM  Cars.CarRental CC 
WHERE CC.CarRentalID = @CarRentalID;
GO