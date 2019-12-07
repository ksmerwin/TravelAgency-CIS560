CREATE OR ALTER PROCEDURE Location.GetCitiesByName
	@CityName NVARCHAR(120),
	@Region  NVARCHAR(120),
	@Country NVARCHAR(120)
AS

SELECT C.CityID
FROM [Location].Cities C
WHERE C.[CityName] = @CityName and @Region =C.Region and @Country =  C.Country
GO