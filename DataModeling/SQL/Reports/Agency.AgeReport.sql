/*
	Report query: Aggregates customers into three age categories, "Young Adult," "Middle Aged", and "Senior."
*/
CREATE OR ALTER PROC Agency.AgeReport
AS
SELECT 
	CASE
		WHEN C.Age BETWEEN 16 AND 29 THEN 'Young Adult'
		WHEN C.Age BETWEEN 30 AND 60 THEN 'Middle Aged'
		WHEN C.Age > 60 THEN 'Senior'
	END AS AgeGroup,
	COUNT(C.CustomerID) AS [Count],
	AVG(C.Budget) AS AverageBudget,
	MIN(C.Budget) AS LowestBudget,
	MAX(C.Budget) AS HighestBudget,
	AVG(C.Age) AS AverageAge,
	Count(T.TripID) AS TripCount

	FROM Agency.Customer C
	INNER JOIN Agency.Trips T ON C.CustomerID = T.CustomerID
	INNER JOIN Agency.Reservations R ON T.TripID = R.TripID
	
	INNER JOIN Airlines.BoardingPass BP ON R.ReservationID = BP.ReservationID
	INNER JOIN Airlines.Flight F ON F.FlightID = BP.FlightID
	INNER JOIN [Location].Cities CY ON CY.CityID = F.CityArrivalID
	GROUP BY
		CASE
			WHEN C.Age BETWEEN 16 AND 29 THEN 'Young Adult'
			WHEN C.Age BETWEEN 30 AND 60 THEN 'Middle Aged'
			WHEN C.AGE > 60 THEN 'Senior'
		END
	