USE TelerikAcademy

SELECT t.Name AS [Town], d.Name AS [Department], COUNT(EmployeeID) AS [Count of employees]
FROM Employees e
  INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
  INNER JOIN Towns t
	ON (SELECT a.TownID FROM Addresses a WHERE e.AddressID = a.AddressID) = t.TownID
GROUP BY t.Name, d.Name