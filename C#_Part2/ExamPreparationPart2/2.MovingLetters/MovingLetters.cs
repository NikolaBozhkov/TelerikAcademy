using System;
using System.Text;

class MovingLetters
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();
        Console.WriteLine(MoveLetters(ExtractLetters(words)));
    }

    public static StringBuilder ExtractLetters(string[] words)
    {
        StringBuilder result = new StringBuilder();
        int maxWordLength = 0;
        for (int i = 0; i < words.Length; i++)
        {
            string currentWord = words[i];
            if (currentWord.Length > maxWordLength)
            {
                maxWordLength = currentWord.Length;
            }
        }

        for (int i = 0; i < maxWordLength; i++)
        {
            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                string currentWord = words[wordIndex];
                if (i < currentWord.Length)
                {
                    result.Append(currentWord[currentWord.Length - 1 - i]);
                }
            }
        }

        return result;
    }

    public static string MoveLetters(StringBuilder message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            char currentChar = message[i];
            int length = message.Length;
            message.Remove(i, 1);
            int indexOfChar = (int)(char.ToLower(currentChar) - 'a') + 1;
            message.Insert((indexOfChar + i) % length, currentChar);
        }

        return message.ToString();
    }
}