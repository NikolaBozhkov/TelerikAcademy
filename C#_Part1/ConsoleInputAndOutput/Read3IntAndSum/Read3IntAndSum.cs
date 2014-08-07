// Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

public class Read3IntAndSum
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the 1st number : ");
            string linea = Console.ReadLine();
            Console.Write("Please enter the 2nd number : ");
            string lineb = Console.ReadLine();
            Console.Write("Please enter the 3rd number : ");
            string linec = Console.ReadLine();
            double a;
            double b;
            double c;
            if (double.TryParse(linea, out a) && double.TryParse(lineb, out b) && double.TryParse(linec, out c))
            {
                Console.WriteLine("the sum of the numbers {0}, {1}, {2} is : {3}", a, b, c, a + b + c);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}