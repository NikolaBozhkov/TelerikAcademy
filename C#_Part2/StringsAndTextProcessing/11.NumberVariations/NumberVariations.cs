// Write a program that reads a number and prints it as a decimal number,
// hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols.

using System;

public class NumberVariations
{
    public static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("The decimal representation of {0}:\n{0,15:D}", num); // Decimal
        Console.WriteLine("The hexadecimal representation of {0}:\n{0,15:X}", num); // Hexadecimal
        Console.WriteLine("The percentage representation of {0}:\n{0,15:P}", num); // Percentage
        Console.WriteLine("The representation of {0} in scientific notation:\n{0,15:E}", num); // Scientific notation
    }
}