namespace Animals
{
    using System;

    public abstract class Animal : ISound
    {
        // Using uint so I don't have to check explicitly for < 0
        private string name;
        private string sex;

        // Constructors
        public Animal(string name, string sex, uint age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        // Properties
        public uint Age { get; private set; }

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
                    throw new ArgumentException("The name of the animal cannot be less than 2 characters.");
                }

                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("The name must contain only letters.");
                    }
                }

                this.name = value;
            }
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }
            private set
            {
                if (value.ToLower() != "f" && value.ToLower() != "m")
                {
                    throw new ArgumentException("Sex can only be \"m\"(male) or \"f\"(female).");
                }

                this.sex = value.ToLower();
            }
        }

        public abstract string ProduceSound();
    }
}