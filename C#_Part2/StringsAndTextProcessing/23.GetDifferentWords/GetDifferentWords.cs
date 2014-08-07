// Write a program that reads a string from the console and lists all different
// words in the string along with information how many times each word is found.

using System;
using System.Linq;

class GetDifferentWords
{
    static void Main()
    {
        string str = "This is a test string, test string for testing different words, different, string, is, a!";

        string[] wordsArr = str.Split(new char[] { ' ', ',', '.', ':', '-', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);

        // Same as the previous task
        var words = wordsArr.GroupBy(word => word);
        foreach (var word in words)
        {
            Console.WriteLine("{0} - {1}", word.Key, word.Count());
        }
    }
}