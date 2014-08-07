// Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

using System;

public class ActionsOnArrOfInt
{
    public static int Min(params int[] array)
    {
        int min = int.MaxValue;
        foreach (int number in array)
        {
            if (number < min)
            {
                min = number;
            }
        }

        return min;
    }

    public static int Max(params int[] array)
    {
        int max = int.MinValue;
        foreach (int number in array)
        {
            if (number > max)
            {
                max = number;
            }
        }

        return max;
    }

    public static decimal Average(params int[] array)
    {
        return Sum(array) / array.Length;
    }

    public static decimal Sum(params int[] array)
    {
        decimal sum = 0;
        foreach (int number in array)
        {
            sum += number;
        }

        return sum;
    }

    public static decimal Product(params int[] array)
    {
        decimal product = 1;
        foreach (int number in array)
        {
            product *= number;
        }

        return product;
    }

    public static void Main()
    {
        Console.WriteLine("The sequence is:");
        for (int i = 1; i < 6; i++)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\nMin = {0}", Min(1, 2, 3, 4, 5));
        Console.WriteLine("Max = {0}", Max(1, 2, 3, 4, 5));
        Console.WriteLine("Average = {0}", Average(1, 2, 3, 4, 5));
        Console.WriteLine("Sum = {0}", Sum(1, 2, 3, 4, 5));
        Console.WriteLine("Product = {0}", Product(1, 2, 3, 4, 5));
    }
}
