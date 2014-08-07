// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;

public class ExtractPalindromes
{
    public static void Main()
    {
        string str = "Palindromes like: ABBA or sth like exe or lamal, maybe even WebbeW or bb";

        string[] words = str.Split(new char[] {' ', ',', ':', '.', '-'}, StringSplitOptions.RemoveEmptyEntries);

        // We check each word, mirror like
        // And if there is a difference at 1 point
        // we make the bool false and the word is not printed
        foreach (string word in words)
        {
            bool palindrome = true;

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    palindrome = false;
                }
            }

            if (palindrome)
            {
                Console.WriteLine(word);
            }
        }
    }
}