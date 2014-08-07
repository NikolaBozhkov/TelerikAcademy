// Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 

using System;
using System.Text;

public class ConvertToUnicode
{
    public static void Main()
    {
        string str = "Hi!";
        StringBuilder result = new StringBuilder(str.Length * 6);
        foreach (char ch in str)
        {
            result.AppendFormat(@"\u{0:X4}", (int)ch);
        }

        Console.WriteLine(result.ToString());
    }
}