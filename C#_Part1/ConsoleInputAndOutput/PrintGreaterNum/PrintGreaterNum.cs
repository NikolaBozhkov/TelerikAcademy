// Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

using System;

public class PrintGreaterNum
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the 1st number: ");
            string line1 = Console.ReadLine();
            Console.Write("Please enter the 2nd number: ");
            string line2 = Console.ReadLine();
            decimal num1;
            decimal num2;
            if (decimal.TryParse(line1, out num1) && decimal.TryParse(line2, out num2))
            {
                Console.WriteLine("The greater number between {0} and {1} is: {2}", num1, num2, Math.Max(num1, num2));
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}