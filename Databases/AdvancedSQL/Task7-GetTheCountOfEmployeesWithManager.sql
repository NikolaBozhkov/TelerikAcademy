USE TelerikAcademy

SELECT Count(EmployeeID) AS [Employees with manager]
FROM Employees
WHERE ManagerID IS NOT NULL