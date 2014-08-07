// Write a program that reverses the words in given sentence.
// Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ReverseSentence
{
    public static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi...";
        string regex = @"\s+|,\s*|\.\s*|!\s*|\?\s*";
        var words = new Stack<string>();

        // We put the words in a Stack after we check if it's valid
        foreach (var word in Regex.Split(sentence, regex))
        {
            if (!String.IsNullOrEmpty(word))
            {
                words.Push(word);
            }
        }

        // Write the exact same amount of words between the punctuation marks(change the position of the words, only)
        foreach (var punctuation in Regex.Matches(sentence, regex))
        {
            // In case of more punctuation marks in the end of the sentence like "..."
            if (words.Count != 0)
            {
                Console.Write(words.Pop() + punctuation);
            }
            else
            {
                Console.Write(punctuation);
            }
        }

        Console.WriteLine();
    }
}