/*
	Creates a new flight
*/
CREATE OR ALTER PROCEDURE Airlines.CreateFlight
	@FlightID INT OUTPUT,
	@AirlineName NVARCHAR(120),
	@DepartureTime DATETIME,
	@ArrivalTime DATETIME,
	@CityDepartureID INT,
	@CityArrivalID INT
AS
INSERT Airlines.Flight(AirlineName, DepartureTime, ArrivalTime, CityDepartureID, CityArrivalID)
VALUES(@AirlineName, @DepartureTime, @ArrivalTime, @CityDepartureID, @CityArrivalID)

SET @FlightID = SCOPE_IDENTITY();
GO