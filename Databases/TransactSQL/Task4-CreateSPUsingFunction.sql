USE BankDB
GO

ALTER PROC dbo.usp_GiveInterestForOneMonth(@AccountID int, @yearlyInterest float)
AS
  UPDATE Accounts
  SET Balance = dbo.ufn_CalcNewSumByInterest(Balance, @yearlyInterest, 1)
  WHERE AccountID = @AccountID
GO

EXEC usp_GiveInterestForOneMonth 1, 0.1
GO

SELECT Balance
FROM Accounts
WHERE AccountID = 1