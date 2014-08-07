// Write a program that reads a text file containing a list of strings,
// sorts them and saves them to another text file.

using System;
using System.Collections.Generic;
using System.IO;

public class SortStringsFromFile
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"unsorted.txt");
        StreamWriter writer = new StreamWriter(@"sorted.txt");

        // The file's content will go here
        List<string> strings = new List<string>();

        using (reader)
        {
            string line = reader.ReadLine();

            // Filling the list
            while (line != null)
            {
                strings.Add(line);
                line = reader.ReadLine();
            }
        }

        // Sorting and writing each element in to the new file
        strings.Sort();
        using (writer)
        {
            for (int elem = 0; elem < strings.Count; elem++)
            {
                writer.WriteLine(strings[elem]);
            }
        }
    }
}