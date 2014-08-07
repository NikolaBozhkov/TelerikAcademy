// Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;

public class NumsNotDivby3And7
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
                Console.WriteLine("The numbers from 1 to {0}, that are not divisible by 3 and 7 are: ", n);
                for (int i = 1; i <= n; i++)
                {
                    if (i % 3 != 0 && i % 7 != 0)
                    {
                        Console.WriteLine(i);
                    }
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