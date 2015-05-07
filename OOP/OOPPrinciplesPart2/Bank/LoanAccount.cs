namespace Bank
{
    public class LoanAccount : Account, IDepositable, IInterest
    {
        // Constructors
        public LoanAccount(Customer customer)
            : base(customer)
        {
        }

        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        // Methods
        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (this.Customer.IsCompany)
            {
                // Catching case in which we call the base with negative months
                if (numberOfMonths >= 0 && numberOfMonths <= 2)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmount(numberOfMonths - 2);
                }
            }
            else
            {
                if (numberOfMonths >= 0 && numberOfMonths <= 3)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmount(numberOfMonths - 3);
                }
            }
        }
    }
}