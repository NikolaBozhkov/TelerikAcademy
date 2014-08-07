// Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

public class ExchangeValueIfGreater
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 2 integers on seperate lines: ");
            string lineA = Console.ReadLine();
            string lineB = Console.ReadLine();
            int a;
            int b;
            int temp;
            if (int.TryParse(lineA, out a) && int.TryParse(lineB, out b))
            {
                if (a > b)
                {
                    temp = a;
                    a = b;
                    b = temp;
                }

                Console.WriteLine("First integer = {0}, Second = {1}", a, b);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}