// * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. Example:
// n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;
using System.Text;

public class Permutations
{
    // I don't know how to expain is short comments the next 3 tasks
    // As I still have difficulty understanding recursions : )
    public static void Swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }

    public static void Permute(int[] array, int current, int length, StringBuilder result)
    {
        if (current == length)
        {
            for (int i = 0; i <= length; i++)
            {
                result.Append(array[i] + " ");
            }

            result.AppendLine();
        }
        else
        {
            for (int i = current; i <= length; i++)
            {
                Swap(ref array[i], ref array[current]);
                Permute(array, current + 1, length, result);
                Swap(ref array[i], ref array[current]);
            }
        }
    }

    public static void Main()
    {
        StringBuilder result = new StringBuilder();
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 1; i <= n; i++)
        {
            array[i - 1] = i;
        }

        Permute(array, 0, array.Length - 1, result);
        Console.WriteLine(result.ToString());
    }
}