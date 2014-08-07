// Write a program that reads two arrays from the console and compares them element by element.

using System;
using System.Collections.Generic;

public class Compare2ArraysByElem
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the 2 arrays: ");
        int length = int.Parse(Console.ReadLine());
        string[] array1 = new string[length];
        string[] array2 = new string[length];
        List<string> differenceReport = new List<string>();
        int differences = 0;
        string lineBreak = new string('-', 20);
        Console.WriteLine("Enter the elements of the 1st array(each on separate line):");
        for (int i = 0; i < length; i++)
        {
            string input = Console.ReadLine();
            array1[i] = input;
        }

        Console.WriteLine("Enter the elements of the 2nd array(each on separate line):");
        for (int i = 0; i < length; i++)
        {
            string input = Console.ReadLine();
            array2[i] = input;
        }

        for (int i = 0; i < length; i++)
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