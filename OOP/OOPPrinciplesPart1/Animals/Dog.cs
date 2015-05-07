namespace Animals
{
    using System;

    public class Dog : Animal, ISound
    {
        public Dog(string name, string sex, uint age)
            : base(name, sex, age)
        {
        }

        public override string ProduceSound()
        {
            return "woof woof...";
        }
    }
}