// Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;
using System.Collections.Generic;
using System.Linq;

public class MinAndMaxOfSequence
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter from how many numbers you want to check: ");
            string line = Console.ReadLine();
            int count;
            List<int> sequence = new List<int>();
            if (int.TryParse(line, out count))
            {
                Console.WriteLine("Now enter the integer numbers, that you want to check(on separate lines): ");
                while (sequence.Count < count)
                {
                    string nums = Console.ReadLine();
                    int num;
                    if (int.TryParse(nums, out num))
                    {
                        sequence.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.Please try again(your record is not lost).");
                    }
                }

                Console.WriteLine("The maximal number in the sequence is {0}\n The minimal number in the sequence is {1}", sequence.Max(), sequence.Min());
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}