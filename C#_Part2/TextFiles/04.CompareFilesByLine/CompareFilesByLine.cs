// Write a program that compares two text files line by line
// and prints the number of lines that are the same and 
// the number of lines that are different.
// Assume the files have equal number of lines.

using System;
using System.IO;

public class CompareFilesByLine
{
    public static void Main()
    {
        StreamReader readerA = new StreamReader(@"fileA.txt");
        StreamReader readerB = new StreamReader(@"fileB.txt");

        // Counters for differences
        int countSame = 0;
        int countDiff = 0;

        using (readerA)
        {
            using (readerB)
            {
                string lineA = readerA.ReadLine();
                string lineB = readerB.ReadLine();
                
                // Looping trough both files and comparing
                while (lineA != null && lineB != null)
                {
                    if (lineA == lineB)
                    {
                        countSame++;
                    }
                    else
                    {
                        countDiff++;
                    }

                    lineA = readerA.ReadLine();
                    lineB = readerB.ReadLine();
                }
            }
        }

        // Printing the info
        Console.WriteLine("The lines that are the same are: {0}", countSame);
        Console.WriteLine("The lines that are different are: {0}", countDiff);
    }
}