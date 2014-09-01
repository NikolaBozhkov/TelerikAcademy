use TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], 
  m.FirstName + ' ' + m.LastName AS [Manager Name],
  a.AddressText AS [Address]
FROM Employees e
  INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
  INNER JOIN Addresses a
	ON e.AddressID = a.AddressID