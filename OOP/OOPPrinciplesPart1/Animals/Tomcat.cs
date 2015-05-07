namespace Animals
{
    using System;

    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, uint age)
            : base(name, "m", age)
        {
        }

        public override string ProduceSound()
        {
            return "(Tomcat) meow meow...";
        }
    }
}
