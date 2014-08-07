// A dictionary is stored as a sequence of text lines containing words and their explanations.
// Write a program that enters a word and translates it by using the dictionary.

using System;
using System.Collections.Generic;

public class Dictonary
{
    public static void Main()
    {
        Dictionary<string, string> dictonary = new Dictionary<string, string>();
        dictonary.Add(".NET", "platform for applications from Microsoft");
        dictonary.Add("CLR", "managed execution environment for .NET");
        dictonary.Add("namespace", "hierarchical organization of classes");

        Console.Write("Enter a word: ");
        string word = Console.ReadLine();
        if (dictonary.ContainsKey(word))
        {
            Console.WriteLine("{0} is a {1}", word, dictonary[word]);
        }
        else
        {
            Console.WriteLine("The word you entered is not contained in the dictonary.");
        }
    }
}