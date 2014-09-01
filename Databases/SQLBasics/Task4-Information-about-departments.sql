use TelerikAcademy

SELECT d.DepartmentID, d.Name, e.FirstName + ' ' + e.LastName as [Name] 
FROM Departments d
	INNER JOIN Employees e
	ON d.ManagerID = e.EmployeeID