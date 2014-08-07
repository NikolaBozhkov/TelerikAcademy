// Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

public class ReadAndPrintOddLines
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"test.txt");
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();

            // Cycle till the end of the file
            while (line != null)
            {
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                // Move to the next line and count it
                line = reader.ReadLine();
                lineNumber++;
            }
        }
    }
}