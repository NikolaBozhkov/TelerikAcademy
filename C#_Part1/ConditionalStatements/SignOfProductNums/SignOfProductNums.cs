// Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

using System;

public class SignOfProductNums
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter 3 real numbers on seperate lines:");
            string lineA = Console.ReadLine();
            string lineB = Console.ReadLine();
            string lineC = Console.ReadLine();
            decimal a;
            decimal b;
            decimal c;
            if (decimal.TryParse(lineA, out a) && decimal.TryParse(lineB, out b) && decimal.TryParse(lineC, out c))
            {
                if ((a > 0 && b > 0 && c < 0) || (b > 0 && c > 0 && a < 0) || (a > 0 && c > 0 && b < 0) || (a < 0 && b < 0 && c < 0))
                {
                    Console.WriteLine("The sign of the product is \"-\"");
                }
                else if ((a < 0 && b < 0 && c > 0) || (b < 0 && c < 0 && a > 0) || (a < 0 && c < 0 && b > 0) || (a > 0 && c > 0 && b > 0))
                {
                    Console.WriteLine("The sign of the product is \"+\"");
                }
                else
                {
                    Console.WriteLine("The product is 0");
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