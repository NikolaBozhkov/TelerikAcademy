// We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.

using System;

public class CheckSubsetSum
{
    public static void Main()
    {
        int[] numbers = new int[5];
        int counter = 0;
        for (int i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i < 32; i++)
        {
            int sum = 0;
            for (int j = 0; j < 5; j++)
            {
                sum += ((i >> j) & 1) * numbers[j];
            }

            if (sum == 0)
            {
                counter++;
            }
        }

        Console.WriteLine(counter + " Subset Sums = 0");
    }
}