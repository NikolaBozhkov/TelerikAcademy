USE BankDB
GO

ALTER PROC dbo.usp_GetAllPeopleWithMoreMoneyThan(@money money)
AS
  SELECT p.FirstName + ' ' + p.LastName AS [Name], a.AccountID
  FROM Accounts a
   INNER JOIN Persons p
	ON a.PersonID = p.PersonID
  WHERE a.Balance > @money
GO

EXEC usp_GetAllPeopleWithMoreMoneyThan 12000