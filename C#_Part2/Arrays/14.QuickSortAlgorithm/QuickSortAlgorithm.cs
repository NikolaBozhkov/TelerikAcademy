// Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

public class QuickSortAlgorithm
{
    // Not much to comment just doing what is said in Wikipedia
    public static List<int> QuickSort(List<int> array)
    {
        if (array.Count <= 1)
        {
            return array;
        }

        int pivot = array[array.Count - 1];
        List<int> lesserArray = new List<int>();
        List<int> greaterArray = new List<int>();
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] <= pivot && i != array.Count - 1)
            {
                lesserArray.Add(array[i]);
            }
            else if (array[i] > pivot && i != array.Count - 1)
            {
                greaterArray.Add(array[i]);
            }
        }

        return MergeArrays(QuickSort(lesserArray), pivot, QuickSort(greaterArray));
    }

    public static List<int> MergeArrays(List<int> lesserArray, int pivot, List<int> greaterArray)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < lesserArray.Count; i++)
        {
            result.Add(lesserArray[i]);
        }

        result.Add(pivot);
        for (int i = 0; i < greaterArray.Count; i++)
        {
            result.Add(greaterArray[i]);
        }

        return result;
    }

    public static void Main()
    {
        List<int> array = new List<int> { 1, 4, 4, 3, 5, 2, 7, 6, 8, 9 };
        array = QuickSort(array);
        for (int i = 0; i < array.Count; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}