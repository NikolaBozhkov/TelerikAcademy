// * Write a program to read your age from the console and print how old you will be after 10 years.

using System;

public class AgeAfterTenYears
{
    public static void Main()
    {
        Console.Write("Enter your age: ");
        int currentAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Your age after 10 years will be {0}.", currentAge + 10);
    }
}

// The missing tasks are not coding tasks : )