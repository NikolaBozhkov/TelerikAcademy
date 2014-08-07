// Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

using System;

public class ValueExchange
{
    public static void Main()
    {
        int numA = 5;
        int numB = 10;
        Console.WriteLine("Before change: A = {0}, B = {1}", numA, numB);
        int temp = numA;
        numA = numB;
        numB = temp;
        Console.WriteLine("After change: A = {0}, B = {1}", numA, numB);
    }
}
