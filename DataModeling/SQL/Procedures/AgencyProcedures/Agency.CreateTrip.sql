CREATE OR ALTER PROCEDURE Agency.CreateTrip
	@TripID INT OUTPUT,
	@DateCreated DATETIMEOFFSET OUTPUT,
	@CustomerID INT,
	@AgentID INT
AS

INSERT Agency.Trips(CustomerID, AgentID)
VALUES (@CustomerID, @AgentID)
SET @TripID = SCOPE_IDENTITY()
SET @DateCreated = 
(SELECT T.DateCreated 
FROM Agency.Trips T
WHERE T.TripID = SCOPE_IDENTITY())
GO