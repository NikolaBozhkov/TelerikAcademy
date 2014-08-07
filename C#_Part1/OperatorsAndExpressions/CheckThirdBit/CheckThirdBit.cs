// Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

public class CheckThirdBit
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter an integer: ");
            string line = Console.ReadLine();
            int num;
            int mask = 1;
            mask <<= 3;
            if (int.TryParse(line, out num))
            {
                int result = num & mask;
                result >>= 3;
                Console.WriteLine("The third bit of {0} is: {1}", num, result);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}

