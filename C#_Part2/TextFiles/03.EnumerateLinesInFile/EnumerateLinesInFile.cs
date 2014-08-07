// Write a program that reads a text file and inserts line numbers in front of each of its lines. 
// The result should be written to another text file.

using System;
using System.IO;

public class EnumerateLinesInFile
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"file.txt");
        StreamWriter writer = new StreamWriter(@"enumeratedFile.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            int lineNumber = 0;
            using (writer)
            {
                while (line != null)
                {
                    writer.WriteLine("{0}.{1}", lineNumber, line);
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}