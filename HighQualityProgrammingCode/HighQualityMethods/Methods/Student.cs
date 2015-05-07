using System;

namespace Methods
{
    public class Student : IBorn
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, DateTime birthDate, string birthLocation)
            : this(firstName, lastName)
        {
            this.BirthDate = birthDate;
            this.BirthLocation = birthLocation;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot be less than 3 characters.");
                }

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Name can contain only letters.");
                    }
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

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot be less than 3 characters.");
                }

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Last name can contain only letters.");
                    }
                }

                this.lastName = value;
            }
        }

        public DateTime BirthDate { get; set; }

        public string BirthLocation { get; set; }

        public bool IsOlderThan(IBorn other)
        {
            bool isOlder = false;

            if (DateTime.Compare(this.BirthDate, other.BirthDate) < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}