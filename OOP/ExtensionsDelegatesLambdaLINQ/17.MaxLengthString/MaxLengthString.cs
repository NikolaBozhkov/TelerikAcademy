using System;
using System.Linq;

public class MaxLengthString
{
    public static void Main()
    {
        string[] array = new string[] { "1", "22", "333", "666666", "4444", "55555" };
        string maxLengthString = 
            (from element in array
            orderby element.Length descending
            select element).First();

        Console.WriteLine("Longest string: {0}, length: {1}", maxLengthString, maxLengthString.Length);
    }
}