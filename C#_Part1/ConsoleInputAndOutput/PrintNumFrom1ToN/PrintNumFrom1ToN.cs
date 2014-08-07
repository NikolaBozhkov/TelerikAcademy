// Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

using System;

public class PrintNumFrom1ToN
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter an integer number: ");
            string line = Console.ReadLine();
            int num;
            if (int.TryParse(line, out num))
            {
                if (num <= 0)
                {
                    Console.WriteLine("All the numbers in the interval[1,{0}] are: ", num);
                    for (int i = 1; i >= num; i--)
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    Console.WriteLine("All the numbers in the interval[1,{0}] are: ", num);
                    for (int i = 1; i <= num; i++)
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