use TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Name]
FROM Employees
WHERE LastName LIKE '%ei%'