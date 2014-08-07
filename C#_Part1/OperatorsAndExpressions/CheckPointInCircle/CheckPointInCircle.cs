// Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;

public class CheckPointInCircle
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter the coordinates of the point(x, y)(firt x, click enter then y):");
            string lineX = Console.ReadLine();
            string lineY = Console.ReadLine();
            double x;
            double y;
            int radius = 5;
            if (double.TryParse(lineX, out x) && double.TryParse(lineY, out y))
            {
                if (((x * x) + (y * y)) <= radius * radius)
                {
                    Console.WriteLine("The point with cordinates \"x\"({0}) and \"y\"({1}) is in the circle K(O, 5) !", x, y);
                }
                else
                {
                    Console.WriteLine("The point with cordinates \"x\"({0}) and \"y\"({1}) is not in the circle K(O, 5) !", x, y);
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