USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Name], Salary, d.Name AS [Department]
FROM Employees e
  INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees
   WHERE DepartmentID = d.DepartmentID)