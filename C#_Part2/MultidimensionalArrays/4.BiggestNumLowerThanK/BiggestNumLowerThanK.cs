// Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

public class BiggestNumLowerThanK
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        int[] arr = new int[lenght];

        // Fill the array
        for (int elem = 0; elem < lenght; elem++)
        {
            Console.WriteLine("Enter element number {0} of the array:", elem);
            arr[elem] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        Array.Sort(arr);

        // The position of k
        int position = Array.BinarySearch(arr, k);

        // Checks about the position
        if (position == 0)
        {
            Console.WriteLine("The largest number that is <= {0} is: {1}", k, arr[0]);
        }
        else if (position > 0)
        {
            Console.WriteLine("The largest number that is <= {0} is: {1}", k, arr[position]);
        }
        else if (position == -1)
        {
            Console.WriteLine("All numbers in the array array are greater than {0}", k);
        }
        else
        {
            Console.WriteLine("The largest number that is <= {0} is: {1}", k, arr[-position - 2]);
        }
    }
}