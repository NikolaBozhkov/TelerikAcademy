// Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Text.RegularExpressions;

public class ExtractSentences
{
    public static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";

        // Just matching sentences containing the word
        foreach (Match match in Regex.Matches(text, @"\s*([^\.]*\b" + word + @"\b.*?\.)"))
        {
            Console.WriteLine(match.Groups[1]);
        }
    }
}