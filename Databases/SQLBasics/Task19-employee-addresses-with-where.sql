use TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID