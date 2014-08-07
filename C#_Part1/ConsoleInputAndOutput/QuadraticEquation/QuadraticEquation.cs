// Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

public class QuadraticEquation
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the coefficient \"a\"(ax^2+bx+c=0): ");
            string linea = Console.ReadLine();
            Console.Write("Please enter the coefficient \"b\"(ax^2+bx+c=0): ");
            string lineb = Console.ReadLine();
            Console.Write("Please enter the coefficient \"c\"(ax^2+bx+c=0): ");
            string linec = Console.ReadLine();
            double a;
            double b;
            double c;
            if (double.TryParse(linea, out a) && double.TryParse(lineb, out b) && double.TryParse(linec, out c))
            {
                double k = b / 2;             
                double discrim = Math.Sqrt((k * k) - (a * c));              
                double root1 = (-k + discrim) / a;
                double root2 = (-k - discrim) / a;
                if (double.IsNaN(discrim))
                {                               
                    Console.WriteLine("D is < 0, so there are no roots !");
                    break;
                }

                Console.WriteLine("The roots of the quadratic equation ({0}x^2+{1}x+{2}=0) are: ", a, b, c);
                Console.WriteLine("x1 = {0}\nx2 = {1}", root1, root2);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}