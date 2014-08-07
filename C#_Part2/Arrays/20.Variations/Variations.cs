// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
// N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;
using System.Text;

public class Variations
{
    public static void GenerateVariations(int[] variation, int index, int n, StringBuilder result)
    {
        if (index == variation.Length)
        {
            for (int i = 0; i < variation.Length; i++)
            {
                result.Append(variation[i] + " ");
            }

            result.AppendLine();
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                variation[index] = i;
                GenerateVariations(variation, index + 1, n, result);
            }
        }
    }

    public static void Main()
    {
        StringBuilder result = new StringBuilder();
        Console.Write("Enter a number N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter a number K: ");
        int k = int.Parse(Console.ReadLine());
        int[] variation = new int[k];
        GenerateVariations(variation, 0, n, result);
        Console.WriteLine(result.ToString());
    }
}