/*
	Gets all customers
*/
CREATE OR ALTER PROCEDURE Agency.GetCustomers
AS

SELECT C.CustomerID, C.Budget, C.[Name], C.Age, C.Sex, C.ContactID
FROM Agency.Customer C
WHERE C.IsDeleted = 0;
GO
