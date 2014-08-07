// Write a program that reads a list of words, 
// separated by spaces and prints the list in an alphabetical order.

using System;

public class ListWordsAlphabetically
{
    public static void Main()
    {
        string str = "banana apple grapes sky cucumber zeta alpha rocket rabbit home house";
        string[] words = str.Split();
        Array.Sort(words);
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}