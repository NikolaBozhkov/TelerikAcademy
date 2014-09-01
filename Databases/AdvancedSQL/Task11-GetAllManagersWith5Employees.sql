USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Name], e.EmployeeID
FROM Employees e
WHERE 5 = 
  (SELECT COUNT(*) FROM Employees
   WHERE ManagerID = e.EmployeeID)