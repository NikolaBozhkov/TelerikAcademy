// * Write a program that exchanges bits {p, p+1, …, p+k-1) 
// with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

using System;

public class ExchangeBits
{
    public static void Main()
    {
        Console.Write("Enter an integer to change: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer p(the first): ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer q(the first of the second): ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer k(to which to change(p -- p + k -1)): ");
        int k = int.Parse(Console.ReadLine());
        int mask = 1;
        int firstBit;
        int secondBit;

        for (int first = p, second = q; first < p + k - 1; first++, second++)
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