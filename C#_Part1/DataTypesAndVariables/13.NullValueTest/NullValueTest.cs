// Create a program that assigns null values to an integer and to double variables.
// Try to print them on the console, try to add some values or the null literal to them and see the result.

using System;

public class NullValueTest
{
    public static void Main()
    {
        
        int? intEx = null;
        double? doubleEx = null;

        Console.WriteLine("Null int: {0}, Null double: {1}", intEx, doubleEx);
        intEx = 5;
        doubleEx = 5.05;
        Console.WriteLine("Value int: {0}, Value double: {1}", intEx, doubleEx);
    }
}
