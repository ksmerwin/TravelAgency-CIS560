/*
	Gets the attraction ticket associated with the reservation ID
*/
CREATE OR ALTER PROCEDURE Attractions.GetAttractionTicket
	@ReservationID INT
AS

SELECT ReservationID, AttractionID, TicketDate, Price
FROM Attractions.AttractionTicket
WHERE ReservationID = @ReservationID;
GO