// Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
// x^2 + 5 = 1x2 + 0x + 5  |5|0|1|

using System;

public class SumOfPolynomials
{
    public static int[] AddPolynomials(int[] firstPoly, int[] secondPoly)
    {
        int[] result = new int[firstPoly.Length > secondPoly.Length ? firstPoly.Length : secondPoly.Length];
        int index = 0;
        while (firstPoly.Length > index || secondPoly.Length > index)
        {
            if (firstPoly.Length <= index)
            {
                result[index] = secondPoly[index];
            }
            else if (secondPoly.Length <= index)
            {
                result[index] = firstPoly[index];
            }
            else
            {
                result[index] = firstPoly[index] + secondPoly[index];
            }

            index++;
        }

        return result;
    }

    public static void PrintPolynomial(int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i > 0; i--)
        {
            Console.Write("{0}x^{1} + ", polynomial[i], i);
        }

        Console.Write("\b\b");
        if (polynomial[0] != 0)
        {
            Console.Write("+ " + polynomial[0]);
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        int[] polyA = { 2, -1, 5 };
        int[] polyB = { 1, 0, 6 };
        int[] result = AddPolynomials(polyA, polyB);
        Console.WriteLine("First polynomial:");
        PrintPolynomial(polyA);
        Console.WriteLine("Second polynomial:");
        PrintPolynomial(polyB);
        Console.WriteLine("Their sum:");
        PrintPolynomial(result);
    }
}