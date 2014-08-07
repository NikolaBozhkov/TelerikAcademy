// Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Text;

public class DecimalToHex
{
    public static string ConvertToHex(int decNum)
    {
        int copy = decNum;
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F' }; // Array of the letters that represent the numbers
        StringBuilder hexNum = new StringBuilder();
        while (copy > 0)
        {
            int reminder = copy % 16;
            copy /= 16;

            // Check if we need to add letter or digit
            if (reminder > 9)
            {
                hexNum.Append(letters[reminder - 10]);
            }
            else
            {
                hexNum.Append(reminder);
            }
        }

        string resultNum = "0x";

        // Fill the result backwards
        for (int i = hexNum.Length - 1; i >= 0; i--)
        {
            resultNum += hexNum[i];
        }

        return resultNum;
    }

    public static void Main()
    {
        Console.Write("Enter a decimal number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("The hexadecimal representation of {0}, is: {1}", num, ConvertToHex(num));
    }
}