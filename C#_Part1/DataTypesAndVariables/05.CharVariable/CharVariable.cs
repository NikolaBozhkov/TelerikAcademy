// Declare a character variable and assign it with the symbol that
// has Unicode code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.

using System;

public class CharVariable
{
    public static void Main()
    {
        char symbol = (char)0x48;

        Console.WriteLine(symbol);
    }
}