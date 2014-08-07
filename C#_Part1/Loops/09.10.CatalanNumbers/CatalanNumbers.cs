// Write a program to calculate the Nth Catalan number by given N.
// The formula is: 2n! / ((n + 1)!n!) = Cn

using System;
using System.Numerics;

public class CatalanNumbers
{
    public static void Main()
    {
        // Get Info
        Console.Write("Enter \"N\": ");
        int n = int.Parse(Console.ReadLine());
        BigInteger factDoubleN = 1;
        BigInteger factNPlusOne = 1;
        BigInteger factN = 1;

        // Calculate factorials
        for (int i = 1; i <= 2 * n; i++)
        {
            factDoubleN *= i;
            // Here I just save 2 more cycles because BigIntegers work slow
            if (i == n)
            {
                factN = factDoubleN;
            }

            if (i == n + 1)
            {
                factNPlusOne = factDoubleN;
            }
        }

        Console.WriteLine("C({0}) equals:", n);
        Console.WriteLine(factDoubleN / (factN * factNPlusOne));
    }
}