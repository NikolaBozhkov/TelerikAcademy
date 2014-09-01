use TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [Name], a.AddressText
FROM Employees e
  INNER JOIN Addresses a
	ON e.AddressID = a.AddressID