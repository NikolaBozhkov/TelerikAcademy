using System;
using System.Collections.Generic;
using System.Text;

class Crossword
{
    static int size = int.Parse(Console.ReadLine());
    static string result = string.Empty;
    static bool solved = false;

    static void Main()
    {
        string[] crossword = new string[size];
        string[] words = new string[size * 2];
        for (int i = 0; i < size * 2; i++)
        {
            words[i] = Console.ReadLine();
        }

        Array.Sort(words);
        GenerateCrossword(crossword, words, 0);

        if (result == string.Empty)
        {
            Console.WriteLine("NO SOLUTION!");
            return;
        }

        Console.WriteLine(result.Trim());
    }

    static void GenerateCrossword(string[] crossword, string[] words, int index)
    {
        if (solved)
        {
            return;
        }

        if (index == size)
        {
            if (!CheckCrossword(crossword, words))
            {
                return;
            }

            for (int i = 0; i < size; i++)
            {
                result += crossword[i] + "\n";
            }
           
            solved = true;
            return;         
        }

        for (int i = 0; i < size * 2; i++)
        {
            crossword[index] = words[i];
            GenerateCrossword(crossword, words, index + 1);
            crossword[index] = null;
        }      
    }

    static bool CheckCrossword(string[] crossword, string[] words)
    {
        StringBuilder word = new StringBuilder();
        for (int charIndex = 0; charIndex < size; charIndex++)
        {
            word.Clear();
            for (int wordIndex = 0; wordIndex < size; wordIndex++)
            {
                word.Append(crossword[wordIndex][charIndex]);
            }

            if (Array.IndexOf(words, word.ToString()) < 0)
            {
                return false;
            }
        }
              
        return true;
    }
}