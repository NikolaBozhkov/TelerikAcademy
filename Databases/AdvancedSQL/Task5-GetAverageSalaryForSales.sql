USE TelerikAcademy

SELECT AVG(Salary) AS [Average salary for Sales]
FROM Employees
WHERE DepartmentID = 
  (SELECT DepartmentID FROM Departments
   WHERE Name = 'Sales')