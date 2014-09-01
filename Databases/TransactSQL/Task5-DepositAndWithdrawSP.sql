USE BankDB
GO

ALTER PROC dbo.usp_DepositMoney(@AccountID int, @money money)
AS
  UPDATE Accounts
  SET Balance = Balance + @money
  WHERE AccountID = @AccountID
GO

ALTER PROC dbo.usp_WithdrawMoney(@AccountID int, @money money)
AS
  UPDATE Accounts
  SET Balance = Balance - @money
  WHERE AccountID = @AccountID
GO

EXEC usp_DepositMoney 3, 1000
EXEC usp_WithdrawMoney 2, 2000
GO

SELECT *
FROM Accounts