// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

public class HexadecimalToBin
{
    public static string ConvertToBin(string hexNum)
    {
        string[] digits = { " 0000", " 0001", " 0010", " 0011", " 0100", " 0101", " 0110", " 0111", " 1000", " 1001" }; // Array of the digits represented by bits to avoid writing 9 more cases
        string result = string.Empty;
        for (int i = 2; i < hexNum.Length; i++)
        {
            switch (hexNum[i])
            {
                case 'A':
                    {
                        result += " 1010";
                    }

                    break;
                case 'B':
                    {
                        result += " 1011";
                    }

                    break;
                case 'C':
                    {
                        result += " 1100";
                    }

                    break;
                case 'D':
                    {
                        result += " 1101";
                    }

                    break;
                case 'E':
                    {
                        result += " 1110";
                    }

                    break;
                case 'F':
                    {
                        result += " 1111";
                    }

                    break;
                default:
                    {
                        result += digits[int.Parse(hexNum[i].ToString())]; // Converting the char digit into string and then into int                       
                    }

                    break;
            }
        }

        return result;
    }

    public static void Main()
    {
        Console.Write("Enter a hexadecimal number(use \"0x\"): ");
        string num = Console.ReadLine();
        Console.WriteLine("The binary representation of {0} is:{1}", num, ConvertToBin(num));
    }
}