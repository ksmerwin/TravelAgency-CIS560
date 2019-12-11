/*
	Retrieves all trips
*/
CREATE OR ALTER PROCEDURE Agency.GetTrips
AS
SELECT T.TripID, T.CustomerID, T.DateCreated, T.AgentID
FROM Agency.Trips T
WHERE T.IsDeleted != 1;
GO