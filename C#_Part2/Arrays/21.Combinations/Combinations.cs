// Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
// N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;
using System.Text;

public class Combinations
{
    public static void GenerateCombinations(int[] combination, int index, int n, int startNum, StringBuilder result)
    {
        if (index == combination.Length)
        {
            for (int i = 0; i < combination.Length; i++)
            {
                result.Append(combination[i] + " ");
            }

            result.AppendLine();
        }
        else
        {
            for (int i = startNum; i <= n; i++, startNum++)
            {
                combination[index] = i;
                GenerateCombinations(combination, index + 1, n, startNum + 1, result);
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
        int[] combination = new int[k];
        GenerateCombinations(combination, 0, n, 1, result);
        Console.WriteLine(result.ToString());
    }
}