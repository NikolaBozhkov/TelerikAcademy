USE TelerikAcademy

SELECT AVG(e.Salary) AS [Average Salary], d.Name AS [Department], e.JobTitle 
FROM Employees e
  INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle