CREATE OR ALTER PROCEDURE Airlines.GetFlight
	@AirlineName NVARCHAR(120),
	@DepartureTime DATETIME,
	@ArrivalTime DATETIME,
	@CityDepartureID INT,
	@CityArrivalID INT
AS
SELECT F.FlightID, F.AirlineName, F.DepartureTime, F.ArrivalTime,
F.CityDepartureID, F.CityArrivalID
FROM Airlines.Flight F
WHERE @AirlineName = F.AirlineName AND
@DepartureTime = F.DepartureTime AND
@ArrivalTime = F.ArrivalTime AND
@CityDepartureID = F.CityDepartureID AND
@CityArrivalID = F. CityArrivalID;
GO