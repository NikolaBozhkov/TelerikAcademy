// Write a program that deletes from given text file all odd lines.
// The result should be in the same file.

using System;
using System.IO;
using System.Text;

public class DeleteAllOddLines
{
    public static void Main()
    {
        StreamReader reader = new StreamReader("textFile.txt");
        StringBuilder newContent = new StringBuilder();

        // Writing only the even lines in the new content
        using (reader)
        {
            string line = reader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                if (lineNumber % 2 == 0)
                {
                    newContent.AppendLine(line);                   
                }

                line = reader.ReadLine();
                lineNumber++;
            }
        }

        StreamWriter writer = new StreamWriter("textFile.txt");
        using (writer)
        {
            writer.Write(newContent);
        }
    }
}