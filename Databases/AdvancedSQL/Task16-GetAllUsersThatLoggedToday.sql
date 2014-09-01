USE TelerikAcademy

SELECT Username
FROM Users
WHERE CONVERT(nvarchar(15), LastLoginTime, 101) = CONVERT(nvarchar(15), GETDATE(), 101)