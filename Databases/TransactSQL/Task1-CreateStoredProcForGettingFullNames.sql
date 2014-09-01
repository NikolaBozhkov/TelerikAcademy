USE BankDB
GO

ALTER PROC dbo.usp_GetFullNamesOfAllPeople
AS
  SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM Persons
GO

EXEC usp_GetFullNamesOfAllPeople
GO