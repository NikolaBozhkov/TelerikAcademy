// Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;

public class CompElemWithNeighbors
{
    public static bool CompWithNeighbors(int position, int[] array)
    {
        // Check if the element exists
        if (position >= 0 && position < array.Length)
        {
            // Compare and check end elements, I think that they are valid too
            if (position == 0 && array[0] > array[1])
            {
                return true;
            }
            else if (position == array.Length - 1 && array[array.Length - 1] > array[array.Length - 2])
            {
                return true;
            }
            else if (array[position] > array[position + 1] && array[position] > array[position - 1])
            {
                return true;
            }
        }

        return false;
    }

    public static void Main()
    {
        bool result = CompWithNeighbors(2, new int[] { 2, 4, 5, 3, 8, 2 });
        Console.WriteLine(result);
    }
}