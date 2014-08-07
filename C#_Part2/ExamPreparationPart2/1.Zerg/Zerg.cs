using System;

class Zerg
{
    static void Main()
    {
        string[] digits = new string[] { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };
        string message = Console.ReadLine();
        decimal number = 0;
        for (decimal i = message.Length - 4, pow = 1; i >= 0; i -= 4, pow *= 15)
        {
            number += Array.IndexOf(digits, message.Substring((int)i, 4)) * pow;
        }

        Console.WriteLine(number);
    }
}