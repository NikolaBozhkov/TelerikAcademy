// Declare two string variables and assign them with following value:
// The "use" of quotations causes difficulties.
// Do the above in two different ways: with and without using quoted strings.

using System;

public class Quotations
{
    public static void Main()
    {
        string doubleQuotes = @"The ""use"" of quotations causes difficulties.";
        string escaping = "The \"use\" of quotations causes difficulties.";

        Console.WriteLine("{0}\n{1}", doubleQuotes, escaping);
    }
}