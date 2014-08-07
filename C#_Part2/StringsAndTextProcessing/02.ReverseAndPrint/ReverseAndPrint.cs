// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample"  "elpmas".

using System;

public class ReverseAndPrint
{
    public static void Main()
    {
        // Get the input, put it in char array
        // and simply reverse the array
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();
        char[] strArray = str.ToCharArray();
        Array.Reverse(strArray);
        string result = new string(strArray);
        Console.WriteLine("The new string is {0}", result);
    }
}