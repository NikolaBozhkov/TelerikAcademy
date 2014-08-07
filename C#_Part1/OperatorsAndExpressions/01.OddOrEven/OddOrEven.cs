// Write an expression that checks if given integer is odd or even.

using System;

public class OddOrEven
{
    public static void Main()
    {
        Console.Write("Enter an integer: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(num % 2 == 0);
    }
}