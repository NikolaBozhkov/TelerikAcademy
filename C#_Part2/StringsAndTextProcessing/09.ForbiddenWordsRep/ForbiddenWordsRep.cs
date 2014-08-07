// We are given a string containing a list of forbidden words and a text containing some of these words.
// Write a program that replaces the forbidden words with asterisks.

using System;
using System.Text.RegularExpressions;

public class ForbiddenWordsRep
{
    public static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "PHP, CLR, Microsoft";

        // Putting the words in an array
        string[] forbWords = words.Split(new char[] { ' ', '\b', '\r', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

        // Replacing all whole forbidden words
        for (int i = 0; i < forbWords.Length; i++)
        {
            text = Regex.Replace(text, @"\b" + forbWords[i] + @"\b", new string('*', forbWords[i].Length));
        }

        Console.WriteLine(text);
    }
}