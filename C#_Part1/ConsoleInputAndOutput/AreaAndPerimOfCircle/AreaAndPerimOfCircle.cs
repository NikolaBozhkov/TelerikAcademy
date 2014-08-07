// Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;

public class AreaAndPerimOfCircle
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the circle's radius: ");
            string line = Console.ReadLine();
            decimal r;
            if (decimal.TryParse(line, out r))
            {
                Console.WriteLine("The area of the circle with radius {0} is: {1}", r, 3.141592654m * (r * r));
                Console.WriteLine("The perimeter of the circle with radius {0} is: {1}", r, 3.141592654m * (2 * r));
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}