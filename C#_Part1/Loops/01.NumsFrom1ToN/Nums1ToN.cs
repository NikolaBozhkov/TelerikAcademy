// Write a program that prints all the numbers from 1 to N.

using System;

public class Nums1ToN
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter to which number you want to print: ");
            string line = Console.ReadLine();
            int n;
            if (int.TryParse(line, out n))
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }

                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}