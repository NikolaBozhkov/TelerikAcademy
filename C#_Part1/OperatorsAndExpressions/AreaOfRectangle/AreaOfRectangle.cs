// Write an expression that calculates rectangle’s area by given width and height.

using System;

public class AreaOfRectangle
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the rectangle's width: ");
            string lineWidth = Console.ReadLine();
            float width;
            Console.Write("Please enter the rectangle's height: ");
            string lineHeight = Console.ReadLine();
            float height;
            if (float.TryParse(lineWidth, out width) && float.TryParse(lineHeight, out height))
            {
                Console.WriteLine("The rectangle's area is: " + (width * height));
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}

