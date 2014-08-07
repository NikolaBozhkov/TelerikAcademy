// Write a program to convert hexadecimal numbers to their decimal representation.

using System;
using System.Linq;

public class HexadecimalToDec
{
    public static int ConvertToDecimal(string hexNum)
    {
        int decNum = 0;

        // i counts after "0x" the power to raise
        // pos counts which element to raise
        for (int i = 0, pos = hexNum.Length - 1; i < hexNum.Length - 2; i++, pos--)
        {
            // Switch on the char
            switch (hexNum[pos])
            {
                case 'A':
                    {
                        decNum += 10 * (int)Math.Pow(16, i);
                    }

                    break;
                case 'B':
                    {
                        decNum += 11 * (int)Math.Pow(16, i);
                    }

                    break;
                case 'C':
                    {
                        decNum += 12 * (int)Math.Pow(16, i);
                    }

                    break;
                case 'D':
                    {
                        decNum += 13 * (int)Math.Pow(16, i);
                    }

                    break;
                case 'E':
                    {
                        decNum += 14 * (int)Math.Pow(16, i);
                    }

                    break;
                case 'F':
                    {
                        decNum += 15 * (int)Math.Pow(16, i);
                    }

                    break;
                default:
                    {
                        // Convert the char digit and raise it  
                        decNum += int.Parse(hexNum[pos].ToString()) * (int)Math.Pow(16, i);                     
                    }

                    break;
            }
        }

        return decNum;
    }

    public static void Main()
    {
        Console.Write("Enter a hexadecimal number(use \"0x\"): ");
        string num = Console.ReadLine();
        Console.WriteLine("The decimal representation of {0} is: {1}", num, ConvertToDecimal(num));
    }
}