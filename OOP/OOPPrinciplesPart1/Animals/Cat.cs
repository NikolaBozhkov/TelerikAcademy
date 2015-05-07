namespace Animals
{
    using System;

    public class Cat : Animal, ISound
    {
        public Cat(string name, string sex, uint age)
            : base(name, sex, age)
        {
        }

        public override string ProduceSound()
        {
            return "meow meow...";
        }
    }
}