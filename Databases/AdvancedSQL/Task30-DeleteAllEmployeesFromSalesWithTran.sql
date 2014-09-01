USE TelerikAcademy

BEGIN TRAN
DELETE FROM Employees
WHERE DepartmentID = (
  SELECT DepartmentID FROM Departments d 
  WHERE d.Name = 'Sales')
ROLLBACK TRAN