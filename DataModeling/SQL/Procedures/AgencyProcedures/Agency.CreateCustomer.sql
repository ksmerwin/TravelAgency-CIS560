/*
	Creates a new customer given the necessary information
*/
CREATE OR ALTER PROCEDURE Agency.CreateCustomer
   @CustomerID INT OUTPUT,
   @Budget FLOAT,
   @Name NVARCHAR(120),
   @Age INT,
   @Sex NVARCHAR(7),
   @ContactID INT  
AS

INSERT Agency.Customer(Budget, [Name], Age, Sex, ContactID)
VALUES(@Budget, @Name, @Age, @Sex, @ContactID);

SET @CustomerID = SCOPE_IDENTITY();
GO
