// Write a program that reads a list of words from a file words.txt 
// and finds how many times each of the words is contained in another file test.txt. 
// The result should be written in the file result.txt and the words should be sorted by
// the number of their occurrences in descending order.
// Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Security;

public class CountOccurOfWords
{
    public static void Main()
    {
        string content = string.Empty;
        int index = -1;
        int count = 0;
        string[] words;
        try
        {
            StreamReader wordsReader = new StreamReader("words.txt");
            StreamReader textReader = new StreamReader("test.txt");
            StreamWriter resultWriter = new StreamWriter("result.txt");
           
            using (wordsReader)
            {
                string listWords = wordsReader.ReadToEnd();
                words = listWords.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }

            int[] values = new int[words.Length];
            using (textReader)
            {
                content = textReader.ReadToEnd().ToLower();
            }

            // Just using the same method to count each word
            for (int i = 0; i < words.Length; i++)
            {
                count = 0;
                while (true)
                {
                    index = content.IndexOf(words[i], index + 1);
                    if (index == -1)
                    {
                        break;
                    }

                    count++;
                }

                values[i] = count;
            }

            Array.Sort(values, words);
            using (resultWriter)
            {
                for (int i = words.Length - 1; i >= 0; i--)
                {
                    resultWriter.WriteLine("{0} has {1} occurunces.", words[i], values[i]);
                    Console.WriteLine("{0} has {1} occurunces.", words[i], values[i]);
                }
            }
        }        
        catch (IOException ioE)
        {
            Console.WriteLine(ioE.Message);
        }
        catch (SecurityException sE)
        {
            Console.WriteLine(sE.Message);
        }
    }
}