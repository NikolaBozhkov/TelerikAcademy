use TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
  m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees m
  RIGHT OUTER JOIN Employees e
	ON e.ManagerID = m.EmployeeID