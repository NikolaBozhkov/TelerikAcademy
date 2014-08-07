// Write a program to convert binary numbers to their decimal representation.

using System;
using System.Linq;

public class BinaryToDecimal
{
    public static int ConvertToDecimal(string binNum)
    {
        int decNum = 0;

        // i counts the power with which we raise 2
        // pos counts the bit we raise
        for (int i = 0, pos = binNum.Length - 1; i < binNum.Length; i++, pos--)
        {                                                                      
            int bit = int.Parse(binNum[pos].ToString());
            decNum += bit * (int)Math.Pow(2, i);
        }

        return decNum;
    }

    public static void Main()
    {
        Console.Write("Enter a binary number: ");
        string binNum = Console.ReadLine();
        Console.WriteLine("The decimal representation of {0} is: {1}", binNum, ConvertToDecimal(binNum));
    }
}