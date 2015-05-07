namespace School
{
    using System;

    public abstract class Person
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must contain more than 2 characters");
                }

                this.name = value;
            }
        }
    }
}