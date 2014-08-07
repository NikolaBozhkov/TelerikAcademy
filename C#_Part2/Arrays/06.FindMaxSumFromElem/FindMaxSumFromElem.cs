// Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

using System;
using System.Text;

public class FindMaxSumFromElem
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        // The builder is for the record of the elements which we sum up
        StringBuilder sumElements = new StringBuilder();
        int k = int.MaxValue;
        int sum = 0;
        Console.WriteLine("Enter the elements of the array(each on separate line):");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        // Just a check, because we can't have more k elements than array elements
        while (k > n)
        {
            Console.Write("Enter the integer K: ");
            k = int.Parse(Console.ReadLine());
        }    

        // Simply sort the array and get the last k elements
        Array.Sort(array);
        for (int i = n - 1; i >= n - k; i--)
        {
            sum += array[i];
            sumElements.Append(array[i] + ", ");
        }

        // Removing the last ", "
        sumElements.Remove(sumElements.Length - 2, 2);
        Console.WriteLine("Greatest sum: {0}, elements({1})", sum, sumElements.ToString());
    }
}