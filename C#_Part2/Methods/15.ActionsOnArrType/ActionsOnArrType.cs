// * Modify your last program and try to make it work for any number type, 
// not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;

public class ActionsOnArrType
{
    // I am trying to get closest to numeric constraint, as there is no such directly
    public static T Min<T>(params T[] array)
        where T : struct, 
                  IComparable,
                  IComparable<T>,
                  IConvertible,
                  IEquatable<T>,
                  IFormattable
    {
        T min = array[0];
        foreach (T element in array)
        {
            if (element.CompareTo(min) < 0)
            {
                min = element;
            }
        }

        return min;
    }

    public static T Max<T>(params T[] array)
        where T : struct, 
                  IComparable,
                  IComparable<T>,
                  IConvertible,
                  IEquatable<T>,
                  IFormattable
    {
        T max = array[0];
        foreach (T element in array)
        {
            if (element.CompareTo(max) > 0)
            {
                max = element;
            }
        }

        return max;
    }

    public static T Average<T>(params T[] array)
        where T : struct, 
                  IComparable,
                  IComparable<T>,
                  IConvertible,
                  IEquatable<T>,
                  IFormattable
    {
        return Sum(array) / (dynamic)array.Length;
    }

    public static T Sum<T>(params T[] array)
        where T : struct, 
                  IComparable,
                  IComparable<T>,
                  IConvertible,
                  IEquatable<T>,
                  IFormattable
    {
        dynamic sum = 0;
        foreach (T element in array)
        {
            sum += element;
        }

        return sum;
    }

    public static T Product<T>(params T[] array)
        where T : struct, 
                  IComparable,
                  IComparable<T>,
                  IConvertible,
                  IEquatable<T>,
                  IFormattable
    {
        dynamic product = 1;
        foreach (T element in array)
        {
            product *= element;
        }

        return product;
    }

    public static void Main()
    {
        Console.WriteLine("The sequence is:");
        for (int i = 1; i < 6; i++)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\nMin = {0}", Min(1, 2, 3, 4, 5));
        Console.WriteLine("Max = {0}", Max(1f, 2f, 3f, 4f, 5f));
        Console.WriteLine("Average = {0}", Average(1d, 2d, 3d, 4d, 5d));
        Console.WriteLine("Sum = {0}", Sum(1m, 2m, 3m, 4m, 5m));
        Console.WriteLine("Product = {0}", Product(1L, 2L, 3L, 4L, 5L));
    }
}