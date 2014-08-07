// Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
// If an invalid number or non-number text is entered, the method should throw an exception.
// Using this method write a program that enters 10 numbers:
// a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

public class ReadNumberMethod
{
    public static int ReadNumber(int start, int end, int current = 0, int numsToEnter = 0)
    {
        Console.Write("Enter a number in the range ({0};{1}): ", start, end);

        // Parsing throws exceptions, we just add 1 more throw for the range
        int num = int.Parse(Console.ReadLine());
        if (num <= start || num >= end)
        {
            throw new ArgumentOutOfRangeException(string.Empty, string.Format("The value must be in the range ({0};{1})", start, end));
        }
        else if (end - num < numsToEnter - current)
        {
            // A little check so that we won't get stuck in an endless cycle
            throw new ArgumentException(string.Format("There must be a range of at least {0} numbers from the new lower bound", numsToEnter - current));
        }

        return num;
    }

    public static void Main()
    {
        int[] numArray = new int[10];
        for (int i = 0, start = 1; i < 10; i++, start = numArray[i - 1])
        {
            bool pass = false;

            // Everything in a while cycle, so we won't skip positions
            while (!pass)
            {
                try
                {
                    numArray[i] = ReadNumber(start, 100, i, 10);                    
                    pass = true;
                }
                catch (OverflowException overFE)
                {
                    Console.WriteLine(overFE.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must be an integer value.");
                }
                catch (ArgumentException argE)
                {
                    Console.WriteLine(argE.Message);
                }
            }
        }
    }
}