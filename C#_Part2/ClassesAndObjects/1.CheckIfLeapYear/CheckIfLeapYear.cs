// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

public class CheckIfLeapYear
{
    public static void Main()
    {
        Console.Write("Enter the year you want to check: ");
        ushort year = ushort.Parse(Console.ReadLine());

        // Not much to comment, just using method from DateTime
        bool leap = DateTime.IsLeapYear(year);
        if (leap)
        {
            Console.WriteLine("{0} is a leap year!", year);
        }
        else
        {
            Console.WriteLine("{0} is not a leap year!", year);
        }
    }
}