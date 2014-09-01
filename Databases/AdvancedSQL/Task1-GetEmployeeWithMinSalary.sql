USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)