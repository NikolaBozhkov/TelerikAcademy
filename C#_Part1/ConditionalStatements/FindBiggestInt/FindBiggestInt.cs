// Write a program that finds the biggest of three integers using nested if statements.

using System;

public class FindBiggestInt
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 3 integer on seperate lines: ");
            string lineA = Console.ReadLine();
            string lineB = Console.ReadLine();
            string lineC = Console.ReadLine();
            int a;
            int b;
            int c;
            if (int.TryParse(lineA, out a) && int.TryParse(lineB, out b) && int.TryParse(lineC, out c))
            {
                if (a > b)
                {
                    if (a > c)
                    {
                        Console.WriteLine("The integer {0} is the biggest", a);
                    }
                    else if (c > a)
                    {
                        Console.WriteLine("The integer {0} is the biggest", c);
                    }
                    else
                    {
                        Console.WriteLine("Two or more integers are equal, there isn't a biggest integer");
                    }
                }
                else if (b > a)
                {
                    if (b > c)
                    {
                        Console.WriteLine("The integer {0} is the biggest", b);
                    }
                    else if (c > b)
                    {
                        Console.WriteLine("The integer {0} is the biggest", c);
                    }
                    else
                    {
                        Console.WriteLine("Two or more integers are equal, there isn't a biggest integer");
                    }
                }
                else
                {
                    if (c > a)
                    {
                        Console.WriteLine("The integer {0} is the biggest", c);
                    }
                    else
                    {
                        Console.WriteLine("Two or more integers are equal, there isn't a biggest integer");
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