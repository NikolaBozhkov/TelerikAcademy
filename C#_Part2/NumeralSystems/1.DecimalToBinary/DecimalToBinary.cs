// Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;

public class DecimalToBinary
{
    public static string ConvertToBinary(int decimalNum)
    {
        int copy = decimalNum; // Saving the original
        string result = string.Empty; // Our binary num as string
        List<int> binaryNum = new List<int>();
        int reminder;

        // Filling the list 
        while (copy > 0)
        {            
            reminder = copy % 2;
            copy /= 2;
            binaryNum.Add(reminder);
        }

        copy++; // I found that this works when you try to convert negatives
        while (copy < 0)
        {
            // Same as top, but this time when we have 0 we write 1 and the opposite
            reminder = (copy % 2) * -1;
            copy /= 2;
            if (reminder == 1)
            {
                binaryNum.Add(0);
            }
            else
            {
                binaryNum.Add(1);
            }          
        } 
    
        binaryNum.Reverse();
        for (int i = 0; i < binaryNum.Count; i++)
        {
            result += binaryNum[i];
        }

        // Here we have 2 ifs to fill the 32 bits accordingly       
        if (decimalNum >= 0)
        {
            result = result.PadLeft(32, '0');
        }
        else
        {
            result = result.PadLeft(32, '1');
        }

        // Putting some spaces to make the output more readable
        for (int i = 0; i < result.Length; i++)
        {
            if ((i + 1) % 5 == 0 && i != 0)
            {
                result = result.Insert(i, " ");
            }
        }

        return result;
    }

    public static void Main()
    {
        Console.Write("Enter a decimal number: ");
        int decNum = int.Parse(Console.ReadLine());
        string binNum = ConvertToBinary(decNum);
        Console.WriteLine("The binary representation of {0} is:\n{1}", decNum, binNum);
    }
}