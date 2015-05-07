namespace Bank
{
    using System;

    public class DepositAccount : Account, IDepositable, IWithdrawable, IInterest
    {
        // Constructors
        public DepositAccount(Customer customer)
            : base(customer)
        {
        }

        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        // Methods
        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            // With the num of months check i am catching the negative number in the base method
            if (this.Balance > 0 && this.Balance < 1000 && numberOfMonths >= 0)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(numberOfMonths);
            }
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("Not enough money in the account.");
            }

            this.Balance -= amount;
        }
    }
}