// * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

using System;

public class MergeSortAlgorithm
{
    public static int[] MergeArrays(int[] firstArray, int[] secondArray)
    {
        int[] array = new int[firstArray.Length + secondArray.Length];
        int firstCount = 0;
        int secondCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (secondCount == secondArray.Length || ((firstCount < firstArray.Length) 
                && (firstArray[firstCount] <= secondArray[secondCount])))
            {
                array[i] = firstArray[firstCount];
                firstCount++;
            }
            else if (firstCount == firstArray.Length || ((secondCount < secondArray.Length)
                && (secondArray[secondCount] <= firstArray[firstCount])))
            {
                array[i] = secondArray[secondCount];
                secondCount++;
            }
        }

        return array;
    }

    // First get the elements 1 by 1 and then sort them
    public static int[] MergeSort(int[] array)
    {
        // Check if we have only 1 element in the array
        if (array.Length <= 1)
        {
            return array;
        }

        int mid = array.Length / 2;
        int[] firstArray = new int[mid];
        int[] secondArray = new int[array.Length - mid];

        // Fill the 2 halves
        for (int i = 0; i < mid; i++)
        {
            firstArray[i] = array[i];
        }

        for (int i = mid, j = 0; i < array.Length; i++, j++)
        {
            secondArray[j] = array[i];
        }

        // Recursively break down the arrays
        firstArray = MergeSort(firstArray);
        secondArray = MergeSort(secondArray);

        // Merge the broken array back together, but sorted
        return MergeArrays(firstArray, secondArray);
    }

    public static void Main()
    {
        int[] array = new int[] { 1, 3, 5, 4, 8, 7, 6, 9, 2 };
        int[] sortedArray = MergeSort(array);

        // Print the result
        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.WriteLine(sortedArray[i]);
        }
    }
}