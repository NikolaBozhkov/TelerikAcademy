// Write a program that enters the coefficients a, b and c of a quadratic equation
// a*x2 + b*x + c = 0
// and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

using System;

public class QuadraticEquation
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the coefficient \"a\"(ax^2+bx+c=0): ");
            string lineA = Console.ReadLine();
            Console.Write("Please enter the coefficient \"b\"(ax^2+bx+c=0): ");
            string lineB = Console.ReadLine();
            Console.Write("Please enter the coefficient \"c\"(ax^2+bx+c=0): ");
            string lineC = Console.ReadLine();
            double a;
            double b;
            double c;
            if (double.TryParse(lineA, out a) && double.TryParse(lineB, out b) && double.TryParse(lineC, out c))
            {
                double k = b / 2;
                double discrim = Math.Sqrt((k * k) - (a * c));
                double root1 = (-k + discrim) / a;
                double root2 = (-k - discrim) / a;
                if (double.IsNaN(root1))
                {
                    Console.WriteLine("D is < 0, so there are no roots !");
                    break;
                }

                Console.WriteLine("The roots of the quadratic equation ({0}x^2+{1}x+{2}=0) are: ", a, b, c);
                if (root1 == root2)
                {
                    Console.WriteLine("x = {0}(double root)", root1);
                }
                else
                {
                    Console.WriteLine("x1 = {0}\nx2 = {1}", root1, root2);
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