// Write a program that finds the most frequent number in an array. Example:
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;

public class FindMostFreqNum
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        int[] array = new int[lenght];
        int currentFreqNum = 0;
        int mostFreqNum = 0;
        int count = 0;
        int backupCount = 0;
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("\nEnter element number {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < lenght; i++)
        {
            currentFreqNum = array[i];
            count++;
            for (int j = i + 1; j < lenght; j++)
            {
                if (array[j] == currentFreqNum)
                {
                    count++;
                }                
            }

            if (count > backupCount)
            {
                mostFreqNum = currentFreqNum;
                backupCount = count;
            }

            count = 0;
        }

        Console.WriteLine("The most frequent number is: {0}", mostFreqNum);
        Console.WriteLine("It occured {0} times.", backupCount);
    }
}