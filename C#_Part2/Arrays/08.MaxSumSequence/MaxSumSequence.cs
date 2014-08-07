// Write a program that finds the sequence of maximal sum in given array.

using System;

public class MaxSumSequence
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        int[] array = new int[lenght];
        int maxSum = int.MinValue;
        int currentSum = 0;
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("\nEnter element number {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < lenght; i++)
        {
            currentSum += array[i];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;                
            }

            if (currentSum < 0)
            {
                currentSum = 0;
            }
        }

        Console.WriteLine("The max sum is: {0}", maxSum);
    }
}