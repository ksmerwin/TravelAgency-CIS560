/*
	Report query: Provides a summary of the cheapest options of hotels and attractions for each city
*/
CREATE OR ALTER PROC Agency.CheapestOptions
AS
WITH HotelInfo(CityID, [Name], Price) AS
(
	SELECT H.CityID, H.[Name], HR.Price
	FROM Hotels.Hotel H 
	INNER JOIN Hotels.HotelReservation HR ON H.HotelID = HR.HotelID
),
AttractionInfo(CityID, [Name], Price) AS
(
	SELECT A.CityID, A.[Name], T.Price
	FROM Attractions.Attraction A 
	INNER JOIN Attractions.AttractionTicket T ON A.AttractionID = T.AttractionID
),
CheapestPrices(CityID, CityName, Country, CheapestHotelPrices, CheapestAttractionPrices) AS
(
	SELECT L.CityID, L.CityName, L.Country,
	MIN(H.Price),
	MIN(A.Price) AS CheapestAttractionPrice
	FROM [Location].Cities L
	LEFT JOIN HotelInfo H ON H.CityID = L.CityID
	LEFT JOIN AttractionInfo A ON A.CityID = L.CityID
	GROUP BY L.CityID, L.CityName, L.Country
)
SELECT DISTINCT P.CityID, P.CityName, P.Country, H.[Name] AS Hotel, P.CheapestHotelPrices, A.[Name] AS Attraction, P.CheapestAttractionPrices 
FROM CheapestPrices P
INNER JOIN HotelInfo H ON (H.CityID = P.CityID AND H.Price = P.CheapestHotelPrices)
INNER JOIN AttractionInfo A ON (A.CityID = P.CityID AND A.Price = P.CheapestAttractionPrices)
ORDER BY P.CheapestHotelPrices, P.CheapestAttractionPrices