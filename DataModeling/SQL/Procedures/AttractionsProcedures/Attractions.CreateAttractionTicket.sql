CREATE OR ALTER PROCEDURE Attractions.CreateAttractionTicket
	@ReservationID INT OUTPUT,
	@TripID INT,
	@AttractionID INT,
	@TicketDate DATE,
	@Price FLOAT
AS

INSERT Agency.Reservations(AttractionTicket, TripID)
VALUES(1, @TripID)

SET @ReservationID = SCOPE_IDENTITY();

INSERT Attractions.AttractionTicket(ReservationID, AttractionID, TicketDate, Price)
VALUES(@ReservationID, @AttractionID, @TicketDate, @Price)
GO