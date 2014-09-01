USE BankDB
GO

--CREATE TABLE Logs(
--  LogID INT IDENTITY,
--  AccountID INT,
--  OldSum money,
--  NewSum money,
--  CONSTRAINT PK_LogID PRIMARY KEY(LogID),
--  CONSTRAINT FK_AccountID FOREIGN KEY(AccountID)
--    REFERENCES Accounts(AccountID)
--)
--GO

ALTER TRIGGER tr_AccountBalanceUpdate ON Accounts FOR UPDATE
AS
BEGIN
  INSERT INTO Logs
  SELECT i.AccountID AS AccountID, 
    (SELECT Balance FROM deleted) AS OldSum, 
    i.Balance AS NewSum
  FROM inserted i
END
GO

EXEC usp_DepositMoney 1, 100
GO

SELECT * 
FROM Logs
