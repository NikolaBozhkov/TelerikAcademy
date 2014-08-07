// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: 
// Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;
using System.Collections.Generic;
using System.Linq;

public class SortingAnArray
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        decimal[] array = new decimal[lenght];
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("Enter element number {0}: ", i + 1);
            array[i] = decimal.Parse(Console.ReadLine());
        }

        List<decimal> workList = array.ToList();
        for (int i = 0; i < lenght; i++)
        {
            decimal min = workList.Min();
            array[i] = min;
            workList.Remove(min);
        }

        Console.Write("The sorted array:\n[ ");
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.WriteLine("]");
    }
}