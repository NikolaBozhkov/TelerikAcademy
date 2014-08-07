// Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

public class FibonacciSequence
{
    public static void Main()
    {
        Console.WriteLine("The first 100 members of the fibonacci sequence are: ");
        Console.WriteLine("1. 0\n2. 1");
        decimal x = 0;
        decimal y = 1;
        for (int i = 2; i <= 100; i++)
        {
            decimal r = x + y;
            Console.WriteLine("{0}. {1}", i, r);
            x = y;
            y = r;
        }
    }
}