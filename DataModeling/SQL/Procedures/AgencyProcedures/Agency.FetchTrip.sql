/*
	Gets a trip given the trip id
*/
CREATE OR ALTER PROCEDURE Agency.FetchTrip
	@TripID INT
AS

SELECT T.TripID, T.CustomerID, T.IsDeleted, T.DateCreated, T.AgentID
FROM Agency.Trips T
WHERE @TripID = T.TripID;
GO