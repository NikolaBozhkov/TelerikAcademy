// Write a program that removes from a text file all words listed in given another text file. 
// Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;

public class RemoveListedWords
{
    public static void Main()
    {
        string content = string.Empty;
        string[] words;
        int index = -1;
        try
        {
            StreamReader listReader = new StreamReader("listOfWords.txt");
            StreamReader textReader = new StreamReader("textFile.txt");

            using (listReader)
            {
                string listWords = listReader.ReadToEnd();
                words = listWords.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }

            using (textReader)
            {
                content = textReader.ReadToEnd();
            }

            // The task before, same thing...
            foreach (string word in words)
            {
                while (true)
                {
                    index = content.IndexOf(word, index + 1);

                    if (index == -1)
                    {
                        break;
                    }

                    content = content.Remove(index, word.Length);
                }
            }
        }       
        catch (IOException ioException)
        {
            // IDK if that is the right way to catch all IO exeptions
            // I really hope it is xD, otherwise there are too many to check each
            Console.WriteLine(ioException.Message);
        }

        Console.WriteLine(content);
    }
}