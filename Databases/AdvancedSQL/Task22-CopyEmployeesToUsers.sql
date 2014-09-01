USE TelerikAcademy 

INSERT INTO Users (Username, Password, FullName)
SELECT SUBSTRING(FirstName, 1, 1) + LastName, SUBSTRING(FirstName, 1, 1) + LastName + '123', FirstName + ' ' + LastName 
FROM Employees