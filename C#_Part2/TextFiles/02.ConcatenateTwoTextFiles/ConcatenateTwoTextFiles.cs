// Write a program that concatenates two text files into another text file.

using System;
using System.IO;

public class ConcatenateTwoTextFiles
{
    public static void Main()
    {
        StreamReader reader1 = new StreamReader(@"file1.txt");
        StreamReader reader2 = new StreamReader(@"file2.txt");
        StreamWriter writer = new StreamWriter(@"resultFile.txt");
        
        //Creating 3 usings for each stream
        using (reader1)
        {
            string firstPart = reader1.ReadToEnd();
            using (reader2)
            {
                string secondPart = "\r\n" + reader2.ReadToEnd();
                using (writer)
                {
                    //Writing both parts together
                    writer.Write(firstPart + secondPart);
                }
            }
        }

        Console.WriteLine("Done!");
    }
}