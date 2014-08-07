// You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;
using System.Collections.Generic;

public class SortArrByLenghtOfElem
{
    public static void Main()
    {
        Console.Write("Please enter the lenght of the array: ");
        int len = int.Parse(Console.ReadLine());
        string[] arr = new string[len];
        for (int elem = 0; elem < len; elem++)
        {
            Console.WriteLine("Please enter element number {0}: ", elem);
            arr[elem] = Console.ReadLine();
        }

        // string[] arr = { "one", "two", "threehee", "four", "lemon", "banana", "ddkkfdfmdkfmdk", "e" }; Test array
        Console.WriteLine("Before the sort:\n");
        PrintArray(arr, len);

        // The sorting...
        Array.Sort(arr, (a, b) => a.Length.CompareTo(b.Length));
        Console.WriteLine("\nAfter the sort:\n");
        PrintArray(arr, len);
    }

    private static void PrintArray(string[] arr, int lenght)
    {
        for (int elem = 0; elem < lenght; elem++)
        {
            Console.WriteLine(arr[elem] + " ");
        }
    }
}