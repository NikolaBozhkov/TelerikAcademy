namespace Bank
{
    public interface IInterest
    {
        decimal CalculateInterestAmount(int numberOfMonths);
    }
}