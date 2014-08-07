// Write a method that returns the maximal element in a portion of array of integers starting at given index.
// Using it write another method that sorts an array in ascending / descending order.

using System;

public class MaxElemInPortionAndSort
{
    public static int MaxElemInPortion(int startIndex, int[] array)
    {
        int max = int.MinValue;

        // Loop from the startIndex
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

    public static int[] SortInAscAndDesc(int[] array, bool descend = false) // descend is for if to sort at descending order
    {
        int helpIndex = 0;
        if (descend)
        {
            // Count start index
            for (int startIndex = 0; startIndex < array.Length; startIndex++)
            {
                int max = int.MinValue;

                // Find max number, from starting index
                for (int i = startIndex; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        helpIndex = i;
                        max = array[i];                       
                    }
                }

                int temp = array[startIndex]; // Swap
                array[startIndex] = max;
                array[helpIndex] = temp;
            }            
        }
        else
        {
            for (int startIndex = 0; startIndex < array.Length; startIndex++)
            {
                // Same as above
                int min = int.MaxValue;
                for (int i = startIndex; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        helpIndex = i;
                        min = array[i];
                    }
                }

                int temp = array[startIndex];
                array[startIndex] = min;
                array[helpIndex] = temp;
            }      
        } 
      
        return array;
    }

    public static void Main()
    {
        int[] arr = new int[] { 2, 5, 7, 9, 90, 2, 5, 7, 1, 23, 7 };
        SortInAscAndDesc(arr, true);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + ", ");
        }

        Console.Write("\b\b \n");
    }
}