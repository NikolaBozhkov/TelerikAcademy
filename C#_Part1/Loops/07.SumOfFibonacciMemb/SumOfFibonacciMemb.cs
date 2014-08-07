// Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
// Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.

using System;

public class SumOfFibonacciMemb
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter to which number you want to calculate:");
            string line = Console.ReadLine();
            int num;
            decimal sum = 1;
            decimal first = 0;
            decimal second = 1;
            decimal next;
            if (int.TryParse(line, out num) && num > 2)
            {
                for (int i = 3; i <= num; i++)
                {
                    next = first + second;
                    sum += next;
                    first = second;
                    second = next;
                }

                Console.WriteLine(sum);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}