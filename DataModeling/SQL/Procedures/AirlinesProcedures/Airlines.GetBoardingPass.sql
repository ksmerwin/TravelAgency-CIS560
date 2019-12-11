/*
	Gets the boarding pass associated with the reservation ID
*/
CREATE OR ALTER PROCEDURE Airlines.GetBoardingPass
	@ReservationID INT
AS
SELECT B.ReservationID, B.FlightID, B.Price
FROM Airlines.BoardingPass B
WHERE @ReservationID = B.ReservationID;
GO