use TelerikAcademy

SELECT TOP 5 FirstName + ' ' + LastName as [Name], Salary
FROM Employees
ORDER BY Salary DESC