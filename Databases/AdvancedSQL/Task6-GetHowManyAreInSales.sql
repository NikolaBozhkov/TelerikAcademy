USE TelerikAcademy

SELECT Count(EmployeeID) AS [Employees in Sales]
FROM Employees
WHERE DepartmentID = 
  (SELECT DepartmentID FROM Departments
   WHERE Name = 'Sales')