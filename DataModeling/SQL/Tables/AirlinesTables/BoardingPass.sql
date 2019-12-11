CREATE TABLE Airlines.BoardingPass 
(
    ReservationID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Agency.Reservations(ReservationID),
    FlightID INT NOT NULL FOREIGN KEY REFERENCES Airlines.Flight(FlightID),
    Price FLOAT NOT NULL
);