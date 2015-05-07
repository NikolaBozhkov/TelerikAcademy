namespace Humans
{
    using System;

    public class Worker : Human
    {
        // Fields and the week salary property
        private uint workHoursPerDay;

        public uint WeekSalary { get; private set; }

        // Constructors
        public Worker(string firstName, string lastName, uint weekSalary, uint workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        // Properties
        public uint WorkHoursPerDay 
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (value > 24 || value <= 0)
                {
                    throw new ArgumentException("Work hours per day must be > 0 and <= 24.");
                }

                this.workHoursPerDay = value;
            }
        }

        // Methods
        public uint MoneyPerHour()
        {
            return (this.WeekSalary / 7) / this.WorkHoursPerDay;
        }
    }
}
