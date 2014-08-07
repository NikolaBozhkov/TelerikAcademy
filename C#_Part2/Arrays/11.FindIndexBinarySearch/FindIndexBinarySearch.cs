// Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;

public class FindIndexBinarySearch
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        int[] array = new int[lenght];
        int first = 0;
        int last = lenght - 1;
        Console.WriteLine("\nThe array will be sorted !");
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("\nEnter element number {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);
        Console.Write("Enter which number's index you want to find: ");
        int goal = int.Parse(Console.ReadLine());
        while (true)
        {
            int mid = (first + last) / 2;
            if (goal < array[mid])
            {
                first -= mid;
            }
            else if (goal > array[mid])
	        {
                first += mid;
	        }
            else
            {
                Console.WriteLine("The number {0} is at index {1}", goal, mid);
                break;
            }
        }
    }
}