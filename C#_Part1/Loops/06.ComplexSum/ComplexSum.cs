// Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

using System;

public class ComplexSum
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 2 numbers(N and X, on separate lines(both > 0)):");
            string lineN = Console.ReadLine();
            string lineX = Console.ReadLine();
            int n;
            int x;
            decimal factN = 1;
            decimal sum = 1;
            if (int.TryParse(lineN, out n) && int.TryParse(lineX, out x) && n > 0 && x > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    factN *= i;
                    sum += factN / (decimal)Math.Pow(x, i);
                }

                Console.WriteLine("The sum S = 1 + 1!/{0} + 2!/{0}^2 + ... + {1}!/{0}^{1} = {2}", x, n, sum);                           
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}