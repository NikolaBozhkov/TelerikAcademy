// Write a program that reads a string from the console and prints all 
// different letters in the string along with information how many times each letter is found. 

using System;
using System.Linq;

public class GetDifferentLetters
{
    public static void Main()
    {
        string str = "This is a random string, just for the test!";

        char[] signs = { ' ', ',', '.', '?', '!', '-', ':' };

        // Getting rid of signs
        foreach (char ch in str)
        {
            if (signs.Contains(ch))
            {
                str = str.Replace(ch.ToString(), string.Empty);
            }
        }

        // Using lambda as char goes to char(put 'i' with 'i')
        var chars = str.ToCharArray().GroupBy(c => c);  
        foreach (var group in chars)
        {
            Console.WriteLine("{0} - {1} times", group.Key, group.Count());
        }
    }
}