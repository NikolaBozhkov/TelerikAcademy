// Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;

public class Get10RandomValues
{
    public static void Main()
    {
        Random randomGenerator = new Random();
        Console.WriteLine("Ten random values in the range [100, 200]: ");
        for (int i = 1; i <= 10; i++)
        {
            // The second limit is 201, because random works with range [p, n)
            int randNum = randomGenerator.Next(100, 201);
            Console.WriteLine("{0}. - {1}", i.ToString().PadLeft(2, ' '), randNum); // Some padding to make the output nicer
        }
    }
}