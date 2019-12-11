/*
	Gets all agents
*/
CREATE OR ALTER PROCEDURE Agency.GetAgents
AS

SELECT A.AgentID, A.[Name], A.Salary
FROM Agency.Agents A;
GO
