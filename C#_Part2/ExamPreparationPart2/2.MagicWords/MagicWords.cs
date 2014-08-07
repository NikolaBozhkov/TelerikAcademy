using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        List<string> words = new List<string>();
        int length = int.Parse(Console.ReadLine());
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            words.Add(Console.ReadLine());
        }

        for (int i = 0; i < words.Count; i++)
        {
            int index = words[i].Length % (words.Count + 1);
            words.Insert(index, words[i]);
            if (index >= i)
            {
                words.RemoveAt(i);
            }
            else
            {
                words.RemoveAt(i + 1);
            }
        }

        int resultLength = string.Join("", words).Length;
        int currentLength = 0;
        int letterIndex = 0;
        while (currentLength != resultLength)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > letterIndex)
                {
                    result.Append(words[i][letterIndex]);
                    currentLength++;
                }
            }

            letterIndex++;
        }

        Console.WriteLine(result.ToString());
    }
}