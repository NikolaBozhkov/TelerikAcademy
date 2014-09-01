USE BankDB
GO

ALTER FUNCTION ufn_CalcNewSumByInterest(@sum money, @yearlyInterest float, @months int)
  RETURNS money
AS
BEGIN
  DECLARE @interestForMonths money
  SET @interestForMonths = (@yearlyInterest * @months) / 12
  RETURN @sum + (@sum * @interestForMonths)
END
GO

SELECT Balance, dbo.ufn_CalcNewSumByInterest(Balance, 0.1, 12) AS [Balance with interest]
FROM Accounts