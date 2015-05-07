namespace Animals
{
    using System;

    public class Kitten : Cat, ISound
    {
        public Kitten(string name, uint age)
            : base(name, "f", age)
        {
        }

        public override string ProduceSound()
        {
            return "(Kitten) meow meow...";
        }
    }
}
