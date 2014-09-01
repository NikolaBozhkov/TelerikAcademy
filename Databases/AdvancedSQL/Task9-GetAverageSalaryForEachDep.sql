USE TelerikAcademy

SELECT AVG(e.Salary) AS [Average salary], d.Name AS [Department]
FROM Employees e
  INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name