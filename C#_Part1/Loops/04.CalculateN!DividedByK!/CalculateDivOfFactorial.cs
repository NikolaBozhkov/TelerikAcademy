// Write a program that calculates N!/K! for given N and K (1<K<N).

using System;

public class CalculateDivOfFactorial
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 2 numbers(N and K(1<K<N), on separate lines):");
            string lineN = Console.ReadLine();
            string lineK = Console.ReadLine();
            int n;
            int k;
            decimal factN = 1;
            decimal factK = 1;
            if (int.TryParse(lineN, out n) && int.TryParse(lineK, out k) && k > 1 && n > k)
            {
                for (int i = 2; i <= n; i++)
                {
                    factN *= i;
                }

                for (int i = 2; i <= k; i++)
                {
                    factK *= i;
                }

                Console.WriteLine("{0}!/{1}!({2}/{3}) = {4}", n, k, factN, factK, factN / factK);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}