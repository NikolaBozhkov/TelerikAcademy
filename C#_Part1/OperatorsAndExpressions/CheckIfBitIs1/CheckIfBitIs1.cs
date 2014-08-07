// Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

using System;

public class CheckIfBitIs1
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the integer number, that you want to check: ");
            string lineV = Console.ReadLine();
            Console.Write("Please enter the position, that you want to check: ");
            string lineP = Console.ReadLine();
            int v;
            int p;
            int mask = 1;
            if (int.TryParse(lineV, out v) && int.TryParse(lineP, out p))
            {
                mask <<= p;
                int result = mask & v;
                result >>= p;
                bool check = result == 1;
                Console.WriteLine("The bit at position {0}, in the number {1} has a value of 1: {2}", p, v, check);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}