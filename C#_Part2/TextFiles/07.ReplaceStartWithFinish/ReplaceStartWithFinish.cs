// Write a program that replaces all occurrences of the substring
// "start" with the substring "finish" in a text file.
// Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;

class ReplaceStartWithFinish
{
    static void Main()
    {         
        StreamReader reader = new StreamReader(@"textFile.txt");

        string content = string.Empty;

        // Printing old and new content
        using (reader)
        {
            content = reader.ReadToEnd();
            Console.WriteLine("Before change:\n{0}\n", content);
            content = content.Replace("start", "finish");
            Console.WriteLine("After change:\n{0}", content);
        }

        StreamWriter writer = new StreamWriter(@"textFile.txt");

        // Writing the new content
        using (writer)
        {
            writer.Write(content);
        }
    }
}