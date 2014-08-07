// Write a program that reads from the console a string of maximum 20 characters.
// If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
// Print the result string into the console.

using System;

public class ReadStringFillBlanks
{
    public static void Main()
    {
        string str;
        while (true)
        {
            Console.WriteLine("Enter a string: ");
            str = Console.ReadLine();
            if (str.Length <= 20)
            {
                break;
            }

            Console.WriteLine("The lenght must be <= 20 !");
        }

        str += new string('*', 20 - str.Length);
        Console.WriteLine("The new string is: {0}", str);
    }
}