// Extend the program to support also subtraction and multiplication of polynomials.

using System;

public class PolynomialsExtended
{
    public static int[] AddPolynomials(int[] firstPoly, int[] secondPoly)
    {
        int[] result = new int[firstPoly.Length > secondPoly.Length ? firstPoly.Length : secondPoly.Length];
        int index = 0;
        while (firstPoly.Length > index || secondPoly.Length > index)
        {
            // In case the lengths are different
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

    public static int[] SubtractPolynomials(int[] firstPoly, int[] secondPoly)
    {
        int[] result = new int[firstPoly.Length > secondPoly.Length ? firstPoly.Length : secondPoly.Length];
        int index = 0;

        // Same as AddPolynomials
        while (firstPoly.Length > index || secondPoly.Length > index)
        {
            if (firstPoly.Length <= index)
            {
                result[index] = -secondPoly[index];
            }
            else if (secondPoly.Length <= index)
            {
                result[index] = firstPoly[index];
            }
            else
            {
                result[index] = firstPoly[index] - secondPoly[index];
            }

            index++;
        }

        return result;
    }

    static int[] MultiplyPolynomials(int[] firstPoly, int[] secondPoly)
    {
        int[] result = new int[firstPoly.Length + secondPoly.Length];

        for (int i = 0; i < firstPoly.Length; i++)
        {
            for (int j = 0; j < secondPoly.Length; j++)
            {
                int position = i + j;
                result[position] += firstPoly[i] * secondPoly[j];
            }
        }

        return result;
    }

    static void PrintPolynomial(int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i > 0; i--)
        {
            if (polynomial[i] != 0)
            {
                Console.Write(" {0}x^{1} +", polynomial[i], i);
            }
        }

        Console.Write("\b\b ");
        if (polynomial[0] != 0)
        {
            Console.Write("+ " + polynomial[0]);
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        int[] polyA = { 2, 4, 6, 1 };
        int[] polyB = { 1, 3, 1 };
        Console.WriteLine("First polynomial:");
        PrintPolynomial(polyA);
        Console.WriteLine("Second polynomial:");
        PrintPolynomial(polyB);
        Console.Write("Addition =");
        PrintPolynomial(AddPolynomials(polyA, polyB));
        Console.Write("Subtraction =");
        PrintPolynomial(SubtractPolynomials(polyA, polyB));
        Console.Write("Multiplication =");
        PrintPolynomial(MultiplyPolynomials(polyA, polyB));
    }
}