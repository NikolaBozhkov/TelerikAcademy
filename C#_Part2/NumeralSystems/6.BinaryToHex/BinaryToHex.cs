// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

public class BinaryToHex
{
    public static string ConvertToHex(string binNum)
    {
        string result = "0x";
        int reminder = binNum.Length % 4;
        if (reminder != 0)
        {
            // Add zeroes if the count of the bits isn't divisible by 4
            binNum = binNum.PadLeft(((binNum.Length / 4) + 1) * 4, '0');
        }

        for (int i = 0; i < binNum.Length; i += 4)
        {
            string getFour = binNum.Substring(i, 4);

            // Too many cases... I couldn't come up with better solution
            switch (getFour)
            {
                case "0000": result += "0"; break;
                case "0001": result += "1"; break;
                case "0010": result += "2"; break;
                case "0011": result += "3"; break;
                case "0100": result += "4"; break;
                case "0101": result += "5"; break;
                case "0110": result += "6"; break;
                case "0111": result += "7"; break;
                case "1000": result += "8"; break;
                case "1001": result += "9"; break;
                case "1010": result += "A"; break;
                case "1011": result += "B"; break;
                case "1100": result += "C"; break;
                case "1101": result += "D"; break;
                case "1110": result += "E"; break;
                case "1111": result += "F"; break;
            }
        }

        return result;
    }

    public static void Main()
    {
        Console.Write("Enter a binary number: ");
        string num = Console.ReadLine();
        Console.WriteLine("The hexadecimal representation of {0} is: {1}", num, ConvertToHex(num));
    }
}