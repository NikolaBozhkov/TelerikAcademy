// Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Collections.Generic;

public class CompareCharArrays
{
    public static void Main()
    {
        // I used the same logic as the previous task : )
        Console.Write("Enter how long you want the 2 char arrays to be: ");
        int lenght = int.Parse(Console.ReadLine());
        char[] array1 = new char[lenght];
        char[] array2 = new char[lenght];
        List<string> differenceReport = new List<string>();
        string lineBreak = new string('-', 20);
        int differences = 0;
        Console.WriteLine("Enter the elements of the first array(each on separate line): ");
        for (int i = 0; i < lenght; i++)
        {
            array1[i] = char.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the elements of the second array(each on separate line): ");
        for (int i = 0; i < lenght; i++)
        {
            array2[i] = char.Parse(Console.ReadLine());
        }

        for (int i = 0; i < lenght; i++)
        {
            if (array1[i] != array2[i])
            {
                differences++;
                string report = string.Format("index {0} ( {1} != {2} )", i, array1[i], array2[i]);
                differenceReport.Add(report);
            }
        }

        Console.WriteLine("There are {0} differences", differences);
        Console.WriteLine(lineBreak);
        foreach (var item in differenceReport)
        {
            Console.WriteLine(item);
        }
    }
}