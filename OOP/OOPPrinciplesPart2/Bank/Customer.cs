namespace Bank
{
    using System;

    public class Customer
    {
        // Fields and automated properties
        private string name;
        private string phoneNumber;

        public bool IsCompany { get; private set; }

        // Constructors
        public Customer(string name, bool isCompany = false)
        {
            this.Name = name;
            this.IsCompany = isCompany;
        }

        public Customer(string name, string phoneNumber, bool isCompany = false)
            : this(name, isCompany)
        {
            this.PhoneNumber = phoneNumber;
        }

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name cannot contain less than 2 characters.");
                }

                this.name = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid phone number(length is not 10).");
                }

                foreach (char ch in value)
                {
                    if (!char.IsDigit(ch))
                    {
                        throw new ArgumentException("Invalid phone number.");
                    }
                }

                this.phoneNumber = value;
            }
        }
    }
}