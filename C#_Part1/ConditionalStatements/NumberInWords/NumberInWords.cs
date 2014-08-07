// Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

using System;

public class NumberInWords
{
    public static void Main()
    {
        while (true)
        {
            string[] numsInWords = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Console.Write("Please enter a digit: ");
            string line = Console.ReadLine();
            int number;
            if (int.TryParse(line, out number) && number >= 0 && number < 10)
            {
                Console.WriteLine(numsInWords[number]);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}