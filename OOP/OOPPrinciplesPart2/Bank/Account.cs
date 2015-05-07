namespace Bank
{
    using System;

    public abstract class Account : IDepositable, IInterest
    {
        // Fields
        private decimal balance;
        private decimal interestRate;
        private Customer customer;
        
        // Constructors
        public Account(Customer customer)
        {
            this.Customer = customer;
        }

        public Account(Customer customer, decimal balance, decimal interestRate)
            : this(customer)
        {
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        // Properties
        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be null.");
                }

                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The balance cannot be negative.");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The interest rate cannot be negative.");
                }

                this.interestRate = value;
            }
        }

        // Methods
        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be negative number.");
            }

            return this.Balance * numberOfMonths * (this.interestRate / 100);
        }
    }
}