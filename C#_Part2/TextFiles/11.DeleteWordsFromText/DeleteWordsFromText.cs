// Write a program that deletes from a text file all words that start with the prefix "test". 
// Words contain only the symbols 0...9, a...z, A…Z, _.
using System;
using System.IO;

public class DeleteWordsFromText
{
    public static void Main()
    {
        StreamReader reader = new StreamReader("textFile.txt");
        char[] punctuationAndMarks = new char[] 
            { 
            ',', ' ', '.', ';', '-', '\n',
            '\r', '!', '@', '#', '$', '%',
            '^', '&', '*', '(', ')' 
            };
        int index = -1;
        string target = "test";
        string content;

        using (reader)
        {
            // Get the content, lower case it so we can delete
            // all words containg 'test' no matter the casing
            content = reader.ReadToEnd();
            content = content.ToLower();
        }

        while (true)
        {
            // Simply taking the index 
            index = content.IndexOf(target, index + 1);

            if (index == -1)
            {
                break;
            }

            int indexOfEnd = content.IndexOfAny(punctuationAndMarks, index);

            // Check if the words starts with test(if test is prefix and not just in the middle)
            if (content[index - 1].ToString().IndexOfAny(punctuationAndMarks) == 0)
            {
                content = content.Remove(index, indexOfEnd - index);
            }
            else
            {
                index++;
            }
        }

        Console.WriteLine(content);
    }
}