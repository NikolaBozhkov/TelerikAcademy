namespace Animals
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // Some animal creating
            Dog[] dogs = new Dog[]
            {
                new Dog("Rex", "m", 10),
                new Dog("Max", "m", 7),
                new Dog("Renny", "f", 4),
                new Dog("Flicky", "m", 3)
            };

            Frog[] frogs = new Frog[]
            {
                new Frog("Froggy", "m", 2),
                new Frog("Dindon", "f", 1),
                new Frog("Ficksy", "f", 4),
                new Frog("Weeky", "m", 3)
            };

            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Kitsy", 3),
                new Kitten("Meowy", 4),
                new Kitten("Rigy", 5),
                new Kitten("Mixy", 2)
            };

            Animal[] tomcats = new Animal[]
            {
                new Tomcat("Tom", 4),
                new Tomcat("Teodor", 5),
                new Tomcat("Fury", 6),
                new Tomcat("Sammy", 4)
            };

            Console.WriteLine("{1}\nAverage age of dogs: {0}\n{1}", AverageAge(dogs), new string('-', 50));

            Console.WriteLine("Average age of frogs: {0}\n{1}", AverageAge(frogs), new string('-', 50));

            Console.WriteLine("Average age of kittens: {0}\n{1}", AverageAge(kittens), new string('-', 50));

            Console.WriteLine("Average age of tomcats: {0}\n{1}", AverageAge(tomcats), new string('-', 50));
        }

        public static uint AverageAge(Animal[] animals)
        {
            // Kinda lots of conversions, but Sum does not accept uint
            return (uint)(animals.Sum(animal => (long)animal.Age) / animals.Length);
        }
    }
}