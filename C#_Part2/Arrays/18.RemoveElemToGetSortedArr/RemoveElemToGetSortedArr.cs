// * Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order.
// Print the remaining sorted array. Example:
// {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

public class RemoveElemToGetSortedArr
{
    public static bool IsSorted(List<int> array)
    {
        for (int i = 0; i < array.Count - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        // Same logic as before, we just check if the array is sorted
        List<int> currentArray = new List<int>();
        List<int> bestArray = new List<int>();
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        List<int> array = new List<int>();
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("\nEnter element number {0}: ", i + 1);
            int elem = int.Parse(Console.ReadLine());
            array.Add(elem);
        }

        for (int i = 0; i <= Math.Pow(2, array.Count) - 1; i++)
        {
            currentArray.Clear();
            for (int j = 1; j <= array.Count; j++)
            {
                if (((i >> (j - 1)) & 1) == 1)
                {
                    currentArray.Add(array[j - 1]);
                }
            }

            if (currentArray.Count > bestArray.Count && IsSorted(currentArray))
            {
                bestArray.Clear();
                bestArray.AddRange(currentArray);
            }
        }

        // Printing the result
        Console.Write("The longest sorted array is the following:\n{");
        for (int i = 0; i < bestArray.Count; i++)
        {
            Console.Write("{0}, ", bestArray[i]);
        }
        Console.WriteLine("\b\b}");
    }
}