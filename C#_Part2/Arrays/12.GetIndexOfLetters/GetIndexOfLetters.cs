// Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

using System;

public class GetIndexOfLetters
{
    public static void Main()
    {
        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();
        foreach (var letter in word.ToLower())
        {
            int index = Array.IndexOf(alphabet, letter);
            Console.WriteLine("[{0}] has an index {1} in the alphabet array", letter, index);
        }
    }
}