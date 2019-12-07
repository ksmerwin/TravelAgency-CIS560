CREATE OR ALTER PROCEDURE Agency.CreateAgent
	@AgentID INT OUTPUT,
	@Name NVARCHAR(100),
	@Salary FLOAT
AS

INSERT Agency.Agents([Name], Salary)
VALUES (@Name, @Salary)

SET @AgentID = SCOPE_IDENTITY();
GO