namespace Humans
{
    using System;

    public abstract class Human
    {
        // Fields
        private string firstName;
        private string lastName;

        // Constructors
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name must contain more than 2 characters.");
                }
                else if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("First name cannot begin with a lowercase letter.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name must contain more than 2 characters.");
                }
                else if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Last name cannot begin with a lowercase letter.");
                }

                this.lastName = value;
            }
        }
    }
}
