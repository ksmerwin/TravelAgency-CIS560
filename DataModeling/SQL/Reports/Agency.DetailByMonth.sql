/*
	Report Query: Provides a summary of each month, querying the average customers per agent, and the total sales
*/
CREATE OR ALTER PROC Agency.DetailByMonth
AS
SELECT
	YEAR(T.DateCreated) AS [Year], MONTH(T.DateCreated) AS [Month] , COUNT(DISTINCT T.TripID) AS NumberOfTrips,
    COUNT(T.TripID)/ CAST(COUNT(DISTINCT AA.AgentID) AS FLOAT) AS AverageTripsPerAgent,
    SUM(AC.Budget) AS TotalSale
FROM Agency.Agents AA 
INNER JOIN  Agency.Trips T ON T.AgentID = AA.AgentID
INNER JOIN Agency.Customer AC ON AC.CustomerID = T.CustomerID
GROUP BY  MONTH(T.DateCreated), YEAR(T.DateCreated)
ORDER BY  MONTH(T.DateCreated) DESC

