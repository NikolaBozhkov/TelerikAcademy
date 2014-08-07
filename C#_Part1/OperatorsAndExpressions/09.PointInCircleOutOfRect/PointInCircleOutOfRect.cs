// Write an expression that checks for given point (x, y) if it is within the
// circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

public class PointInCircleOutOfRect
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
            int radius = 3;
            if (double.TryParse(lineX, out x) && double.TryParse(lineY, out y))
            {              
                if ((Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2)) <= radius * radius &&
                    !((x >= -1) && (x <= 5) && (y >= -1) && (y <= 1)))
                {
                    Console.WriteLine("The point with cordinates \"x\"({0}) and \"y\"({1}) is in the circle K((1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2) !", x, y);
                }
                else
                {
                    Console.Write("The point with cordinates \"x\"({0}) and \"y\"({1}) is NOT in the circle K((1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2): ", x, y);
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