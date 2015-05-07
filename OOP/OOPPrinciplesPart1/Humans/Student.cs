namespace Humans
{
    using System;

    public class Student : Human
    {
        // Fields
        private int grade;

        // Constructors
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        // Properties
        public int Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (grade < 1 || grade > 12)
                {
                    throw new ArgumentException("Grade must be between 1 and 12.");
                }

                this.grade = value;
            }
        }
    }
}
