USE TelerikAcademy

UPDATE Users
SET Password = '12345678'
WHERE GroupID = 3

UPDATE Groups
SET Name = 'HQC'
WHERE Name = 'HQPC'