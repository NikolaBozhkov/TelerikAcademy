// Write a program that reads an integer number and calculates and prints its square root. 
// If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;
using System.Linq;

public class CalcSqrtWithCheck
{
    public static void Main()
    {
        Console.Write("Enter a number: ");   
        string str = Console.ReadLine();
        try
        {
            int num = int.Parse(str);
            if (num < 0)
            {
                // We throw new exception for the range
                // Later we catch it with ArgumentException
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine("The square root of {0} is: {1}", num, Math.Sqrt(num));
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid number.");
        }
        finally
        {
            Console.WriteLine("Good Bye");
        }
    }
}