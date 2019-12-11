/*
	Retrives the contact information of a customer
*/
CREATE OR ALTER PROCEDURE Agency.RetrieveCustomerContactInfo
	@ContactID INT
AS

SELECT CI.ContactID, CI.BillingAddress, CI.Phone, CI.Email, CI.CityID
FROM Agency.ContactInfo CI
WHERE CI.ContactID = @ContactID
GO
