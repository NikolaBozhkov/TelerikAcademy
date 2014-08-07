// Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

using System;

public class CalcGCD
{
    public static void Main()
    {
        // Take input
        Console.Write("Enter the first number: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int second = int.Parse(Console.ReadLine());

        // Switch places if needed
        if (first < second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        // Get initial reminder and result
        Console.Write("The GCD(Greatest Common Divisor) of {0} and {1} is: ", first, second);
        int reminder = first % second;
        int result = second;

        // Run the algorithm
        while (reminder != 0)
        {            
            first = second;
            second = reminder;
            reminder = first % second;
            result = second;
        }

        Console.WriteLine(result);
    }
}