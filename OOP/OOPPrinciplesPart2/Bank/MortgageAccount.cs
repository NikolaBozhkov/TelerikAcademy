namespace Bank
{
    using System;

    public class MortgageAccount : Account, IDepositable, IInterest
    {
        // Constructors
        public MortgageAccount(Customer customer)
            : base(customer)
        {
        }

        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        // Methods
        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (this.Customer.IsCompany)
            {
                if (numberOfMonths >= 12)
                {
                    return this.Balance * 12 * (this.InterestRate / 200)
                        + base.CalculateInterestAmount(numberOfMonths - 12);
                }
                else
                {
                    if (numberOfMonths < 0)
                    {
                        throw new ArgumentException("Number of months cannot be negative number.");
                    }

                    return this.Balance * numberOfMonths * (this.InterestRate / 200);
                }
            }
            else
            {
                // Again catching the less than 0 exception in the base class
                if (numberOfMonths >= 0 && numberOfMonths <= 6)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmount(numberOfMonths - 6);
                }
            }
        }
    }
}