// Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.Collections.Generic;
using System.IO;

public class ExtractTextFromXML
{
    public static void Main()
    {
        StreamReader reader = new StreamReader("XML.txt");
        string content;
        using (reader)
        {
            content = reader.ReadToEnd();           
        }

        // Split this way to get all tags to start with '<'
        string[] wordsAndTags = content.Split(new char[] { '\r', '\n', '>' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> words = new List<string>();

        // Clear the words from the tags, because they look like this "Pesho</name
        foreach (string word in wordsAndTags)
        {
            if (word[0] != '<')
            {
                // Add the cleared word
                words.Add(word.Substring(0, word.IndexOf('<')));
            }
        }

        // Print the extracted words
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}