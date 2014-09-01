USE TelerikAcademy

SELECT TOP(1) t.Name, COUNT(EmployeeID) AS [Number Of Employees] 
FROM Towns t
  INNER JOIN Addresses a
    ON t.TownID = a.TownID
  INNER JOIN Employees e
    ON e.AddressID = a.AddressID
GROUP BY t.Name
ORDER BY [Number Of Employees] DESC
