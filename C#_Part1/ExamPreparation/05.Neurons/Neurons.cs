using System;
using System.Collections.Generic;

class Neurons
{
    static void Main()
    {
        // Take input and Process
        long num = long.Parse(Console.ReadLine());
        List<long> output = new List<long>();

        while (num != -1)
        {
            // Mark
            int firstMark = -1;
            int secondMark = -1;
            for (int i = 0, mask = 1; i < 32; i++, mask <<= 1)
            {
                if ((num & mask) >> i == 1 && firstMark == -1)
                {
                    firstMark = i;
                }

                if ((num & mask) >> i == 1 && (num & mask << 1) >> i == 0)
                {
                    secondMark = i;
                }
            }
            
            // Check if there are no 1, or only 1, or only 1 1
            if (firstMark == -1)
            {
                firstMark = 0;
                secondMark = 0;
                num = 1;
            }
            else if (firstMark != -1 && secondMark == -1 && (num & (1 << 31)) >> 31 == 1)
            {
                secondMark = 31;
            }
            else if (firstMark != -1 && secondMark == -1)
            {
                secondMark = firstMark;
            }
            // Swap
            long maskSecond = 1;
            maskSecond <<= firstMark;
            for (int i = firstMark; i <= secondMark; i++, maskSecond <<= 1)
            {
                if ((num & maskSecond) >> i == 1)
                {
                    num &= ~maskSecond;
                }
                else if ((num & maskSecond) >> i == 0)
                {
                    num |= maskSecond;
                }
            }

            // Output
            output.Add(num);
            num = long.Parse(Console.ReadLine());
        }

        foreach (long item in output)
        {
            Console.WriteLine(item);
        }
    }
}