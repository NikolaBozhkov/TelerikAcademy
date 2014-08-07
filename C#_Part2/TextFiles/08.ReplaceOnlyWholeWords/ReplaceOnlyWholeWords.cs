// Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text.RegularExpressions;

public class ReplaceOnlyWholeWords
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"textFile.txt");
        string content = string.Empty;

        // Printing old and new content
        using (reader)
        {
            content = reader.ReadToEnd();
            Console.WriteLine("Before change:\n{0}\n", content);
            content = Regex.Replace(content, @"\bstart\b", "finish");
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