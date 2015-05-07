namespace Bank
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Feel free to test
            Account[] accounts = 
            {
                new DepositAccount(new Customer("Some dude"), 10010, 2),
                new LoanAccount(new Customer("Company", true), 1000, 3),
                new MortgageAccount(new Customer("Company2", true), 30000, 4)
            };

            foreach (var account in accounts)
            {
                Console.WriteLine("{0} with balance {1} and interest rate {2} has interest {3:f2} for 12 months",
                    account.GetType().Name, account.Balance, account.InterestRate, account.CalculateInterestAmount(12));
            }
        }
    }
}