// Write a program that safely compares floating-point numbers with 
// precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true

using System;

public class PrecisiveComparing
{
    public static void Main()
    {
        // float a = float.Parse(Console.ReadLine());
        // float b = float.Parse(Console.ReadLine());

        float a = 5.00000001f;
        float b = 5.00000003f;

        Console.WriteLine(a == b);
    }
}
