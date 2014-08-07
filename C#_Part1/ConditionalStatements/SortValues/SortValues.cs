// Sort 3 real values in descending order using nested if statements.

using System;

public class SortValues
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 3 real numbers on separate lines:");
            string lineA = Console.ReadLine();
            string lineB = Console.ReadLine();
            string lineC = Console.ReadLine();
            decimal a;
            decimal b;
            decimal c;
            if (decimal.TryParse(lineA, out a) && decimal.TryParse(lineB, out b) && decimal.TryParse(lineC, out c))
            {
                if (a >= b && a >= c)
                {
                    if (b > c)
                    {
                        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", a, b, c);
                    }
                    else
                    {
                        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", a, c, b);
                    }
                }
                else if (b >= a && b >= c)
                {
                    if (a > c)
                    {
                        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", b, a, c);
                    }
                    else
                    {
                        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", b, c, a);
                    }
                }
                else if (c >= a && c >= b)
                {
                    if (a > b)
                    {
                        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", c, a, b);
                    }
                    else
                    {
                        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", c, b, a);
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