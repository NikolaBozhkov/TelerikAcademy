// Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;
using System.Numerics;

public class CalcComplexFactDivision
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 2 numbers(N and K(1<N<K), on separate lines):");
            string lineN = Console.ReadLine();
            string lineK = Console.ReadLine();
            int n;
            int k;
            decimal factN = 1;
            decimal factK = 1;
            decimal factBoth = 1;
            if (int.TryParse(lineN, out n) && int.TryParse(lineK, out k) && n > 1 && k > n)
            {
                for (int i = 2; i <= n; i++)
                {
                    factN *= i;
                }

                for (int i = 2; i <= k; i++)
                {
                    factK *= i;
                }

                for (int i = 2; i <= (k - n); i++)
                {
                    factBoth += i;
                }

                BigInteger preresult = (BigInteger)factN * (BigInteger)factK;
                Console.WriteLine("{0}!*{1}! / ({1}-{0})! ( {2}*{3} / ({1}-{0})! ) = {4}", n, k, factN, factK, preresult / (BigInteger)factBoth);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}