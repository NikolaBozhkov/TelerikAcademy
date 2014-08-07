// Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;
using System.Collections.Generic;

public class BinaryReprOfShort
{
    public static string ShortToBinary(short decNum)
    {
        int copy = decNum; // Saving the original
        string result = string.Empty; // Our binary num as string
        List<int> binNum = new List<int>();
        int reminder;

        // Filling the list
        while (copy > 0) 
        {
            reminder = copy % 2;
            copy /= 2;
            binNum.Add(reminder);
        }

        copy += 1; // I found that this works when you try to convert negatives
        while (copy < 0)
        {
            // Same as top, but this time when we have 0 we write 1 and the opposite
            reminder = (copy % 2) * -1;
            copy /= 2;
            if (reminder == 1)
            {
                binNum.Add(0);
            }
            else
            {
                binNum.Add(1);
            }
        }

        binNum.Reverse();
        for (int i = 0; i < binNum.Count; i++)
        {
            result += binNum[i];
        }

        // Here we have 2 ifs to fill the 16 bits accordingly      
        if (decNum >= 0)
        {
            result = result.PadLeft(16, '0');
        }
        else
        {
            result = result.PadLeft(16, '1');
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
        short shortNum = short.Parse(Console.ReadLine());
        string binNum = ShortToBinary(shortNum);
        Console.WriteLine("The binary representation of {0} is:\n{1}", shortNum, binNum);
        //// I have no idea about task 9, I read 1 hour about it, still can't understand why stuff are the way they are
    }
}