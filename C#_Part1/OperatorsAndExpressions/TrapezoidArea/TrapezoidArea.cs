// Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

public class TrapezoidArea
{
    public static void Main()
    {
         while (true)
         {
             Console.WriteLine("Please enter the sides of the trapezoid and the height");
             Console.Write("a = ");
             string lineA = Console.ReadLine();
             Console.Write("b = ");
             string lineB = Console.ReadLine();
             Console.Write("h = ");
             string lineH = Console.ReadLine();
             double a;
             double b;
             double h;
             if (double.TryParse(lineA, out a) && double.TryParse(lineB, out b) && double.TryParse(lineH, out h))
             {
                 Console.WriteLine("The area of the trapezoid is: " + (((a + b) * h) / 2));
                 break;
             }
             else
             {
                 Console.WriteLine("Invalid input.");
             }
        }
    }
}