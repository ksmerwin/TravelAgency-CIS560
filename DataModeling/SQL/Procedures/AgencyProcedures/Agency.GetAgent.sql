/*
	Gets an agent given their id
*/
CREATE OR ALTER PROCEDURE Agency.GetAgent
	@AgentID INT
AS
SELECT A.AgentID, A.[Name], A.Salary
FROM Agency.Agents A
WHERE A.IsDeleted = 0
AND @AgentID = A.AgentID;
GO