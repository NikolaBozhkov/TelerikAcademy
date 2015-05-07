using System;

public class ExtensionsExample
{
    public static void Main()
    {
        int[] items = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine("Sum = {0}", items.Sum());
        Console.WriteLine("Product = {0}", items.Product());
        Console.WriteLine("Min = {0}", items.Min());
        Console.WriteLine("Max = {0}", items.Max());
        Console.WriteLine("Average = {0}", items.Average());
    }
}