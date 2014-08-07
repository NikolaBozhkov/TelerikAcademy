// Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
// Use the method from the previous exercise.

using System;

public class GetElementBiggerThanNeighbors
{
    // The name is so long xD
    public static int GetIndOfElementBiggerThanNeighbors(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (CompElemWithNeighbors.CompWithNeighbors(i, array))
            {
                return i;
            }
        }

        return -1;
    }

    public static void Main()
    {
        Console.WriteLine(GetIndOfElementBiggerThanNeighbors(new int[] { 2, 5, 7, 7, 3, 7, 8, 7 }));
    }
}