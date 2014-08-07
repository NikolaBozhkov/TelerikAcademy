// Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Collections.Generic;
using System.Text;

public class ConvertBetweenTwoNumS
{
    public static int ConvertToDecimal(string num, int baseS)
    {
        int decNum = 0;

        // i counts the power to raise
        // pos counts which element to raise
        for (int i = 0, pos = num.Length - 1; i < num.Length; i++, pos--)
        {
            // Switch on the char
            switch (num[pos])
            {
                case 'A':
                    {
                        decNum += 10 * (int)Math.Pow(baseS, i);                  
                    }

                    break;
                case 'B':
                    {
                        decNum += 11 * (int)Math.Pow(baseS, i);
                    }

                    break;
                case 'C':
                    {
                        decNum += 12 * (int)Math.Pow(baseS, i);                        
                    }

                    break;
                case 'D':
                    {
                        decNum += 13 * (int)Math.Pow(baseS, i);                    
                    }

                    break;
                case 'E':
                    {
                        decNum += 14 * (int)Math.Pow(baseS, i);                      
                    }

                    break;
                case 'F':
                    {
                        decNum += 15 * (int)Math.Pow(baseS, i);                   
                    }

                    break;
                default:
                    {
                        decNum += int.Parse(num[pos].ToString()) * (int)Math.Pow(baseS, i); // Convert the char digit and raise it                      
                    }

                    break;
            }
        }

        return decNum;
    }

    public static string ConvertFromDec(int decNum, int baseD)
    {
        int copy = decNum;
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F' }; // Array of the letters that represent the numbers
        StringBuilder hexNum = new StringBuilder();
        while (copy > 0)
        {
            int reminder = copy % baseD;
            copy /= baseD;

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

        string resNum = string.Empty;

        // Fill the result backwards
        for (int i = hexNum.Length - 1; i >= 0; i--)
        {
            resNum += hexNum[i];
        }

        return resNum;
    }

    public static void Main()
    {
        Console.Write("Enter the number you want to convert: ");
        string num = Console.ReadLine();
        Console.Write("Enter the base this number has: ");
        int baseS = int.Parse(Console.ReadLine());
        Console.Write("Enter the base you want the number to be converted to: ");
        int baseD = int.Parse(Console.ReadLine());

        // Simply convert to decimal and then to the wanted numeral system of given base
        string newNum = ConvertFromDec(ConvertToDecimal(num, baseS), baseD);
        Console.WriteLine("The number {0} of base {1} has a representation of:\n{2} of base {3}", num, baseS, newNum, baseD);
    }
}