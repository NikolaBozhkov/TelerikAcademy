﻿// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

public class ExchangeGivenBits
{
    public static void Main()
    {
        Console.Write("Enter an integer to change: ");
        int num = int.Parse(Console.ReadLine());
        int mask = 1;
        int firstBit;
        int secondBit;

        for (int first = 3, second = 24; first < 6; first++, second++)
        {
            mask <<= first;
            firstBit = mask & num;
            firstBit >>= first;
            mask >>= first;
            mask <<= second;
            secondBit = mask & num;
            secondBit >>= second;
            mask >>= second;
            if (firstBit == 1)
            {
                firstBit <<= second;
                num |= firstBit;               
            }
            else
            {              
                firstBit = ~(1 << second);
                num &= firstBit;
            }

            if (secondBit == 1)
            {
                secondBit <<= first;
                num &= secondBit;
            }
            else
            {               
                secondBit = ~(1 << first);
                num &= secondBit;
            }
        }

        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
    }
}