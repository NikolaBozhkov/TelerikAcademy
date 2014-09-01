use TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Name], d.Name, e.HireDate
FROM Employees e
  INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE (d.Name IN ('Sales', 'Finance') AND e.HireDate BETWEEN '1995/1/1' AND '2005/12/31')