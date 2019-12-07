CREATE OR ALTER PROCEDURE Agency.CreateContactInfo
   @BillingAddress NVARCHAR(200),
   @Phone NVARCHAR(30),
   @Email NVARCHAR(50),
   @CityID INT,
   @ContactID INT OUTPUT
  
AS
INSERT Agency.ContactInfo(BillingAddress, Phone, Email, CityID)
VALUES(@BillingAddress, @Phone, @Email, @CityID)

SET @ContactID = SCOPE_IDENTITY();
GO
