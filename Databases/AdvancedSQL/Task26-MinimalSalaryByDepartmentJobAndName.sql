USE TelerikAcademy

SELECT d.Name AS [Department], e.JobTitle, MIN(e.Salary) AS [Minimal Salary], e.FirstName
FROM Employees e
  INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName