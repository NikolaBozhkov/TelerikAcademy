// Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;
using System.Text;

public class SieveOfEratosthenesAlg
{
    public static void Main()
    {
        // I use stringbuilder because it's much much faster
        // 10 million + 1, because I check 10 million too
        bool[] numbers = new bool[(int)1E7 + 1];
        StringBuilder result = new StringBuilder();
        for (int prime = 2; prime < Math.Sqrt(numbers.Length); prime++)
        {
            if (!numbers[prime])
            {
                for (int i = prime * prime; i < numbers.Length; i += prime)
                {
                    numbers[i] = true;
                }
            }
        }

        for (int i = 2; i < numbers.Length; i++)
        {
            if (!numbers[i])
            {
                result.AppendFormat("{0} ", i);
            }
        }

        // Printing is super slow
        Console.WriteLine(result.ToString());
    }
}

