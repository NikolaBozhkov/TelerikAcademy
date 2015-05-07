namespace Animals
{
    using System;

    public class Frog : Animal, ISound
    {
        public Frog(string name, string sex, uint age)
            : base(name, sex, age)
        {
        }

        public override string ProduceSound()
        {
            return "croak croak...";
        }
    }
}