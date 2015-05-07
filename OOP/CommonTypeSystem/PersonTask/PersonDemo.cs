namespace PersonTask
{
    using System;

    public class PersonDemo
    {
        public static void Main()
        {
            Person withoutAge = new Person("Pesho");
            Person withAge = new Person("Ivaylo", 25);

            Console.WriteLine(withoutAge.ToString());
            Console.WriteLine(withAge.ToString());
        }
    }
}