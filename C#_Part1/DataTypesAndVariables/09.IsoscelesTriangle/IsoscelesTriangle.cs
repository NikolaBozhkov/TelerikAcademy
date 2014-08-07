// Write a program that prints an isosceles triangle of 9 copyright symbols ©.
// Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

using System;

public class IsoscelesTriangle
{
    public static void Main()
    {
        char copyRight = (char)169;

        Console.WriteLine("   {0}", copyRight);
        Console.WriteLine("  {0} {0}", copyRight);
        Console.WriteLine(" {0}   {0}", copyRight);
        Console.WriteLine("{0} {0} {0} {0}", copyRight);
    }
}