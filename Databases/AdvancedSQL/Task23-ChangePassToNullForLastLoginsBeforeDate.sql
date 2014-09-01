USE TelerikAcademy

UPDATE Users
SET Password = NULL
WHERE LastLoginTime < '20100310'
