USE TelerikAcademy

SELECT t.Name, COUNT(DISTINCT e.ManagerID) AS [Managers]
FROM Employees e
  INNER JOIN Employees m
    ON e.ManagerID = m.EmployeeID
  INNER JOIN Addresses a
    ON a.AddressID = m.AddressID
  INNER JOIN Towns t
    ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Managers] DESC