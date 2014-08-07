// Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

public class GetMaxMethod
{
    public static int GetMax(int a, int b)
    {
        if (a < b)
        {
            a = b;
        }

        return a;
    }

    public static void Main()
    {
        Console.WriteLine("Enter 3 integers on separate lines.");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int preResult = GetMax(a, b);
        int result = GetMax(preResult, c);
        Console.WriteLine("The biggest of them is {0} !", result);
    }
}