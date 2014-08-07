// Find online more information about ASCII (American Standard Code for Information Interchange)
// and write a program that prints the entire ASCII table of characters on the console.

using System;

public class ASCIITable
{
    public static void Main()
    {
        // Setting up the table
        Console.Write("Dec".PadRight(10));
        Console.Write("Hex".PadRight(10));
        Console.Write("ASCII");
        Console.WriteLine("\n");

        // Using "for" cycle to print it
        for (int i = 0; i < 128; i++)
        {
            // Get ascii character
            char c = (char)i;

            // Get string to show
            string show = string.Empty;
            if (char.IsWhiteSpace(c))
            {
                show = c.ToString();
                switch (c)
                {
                    case '\t':
                        show = "\\t";
                        break;
                    case ' ':
                        show = "space";
                        break;
                    case '\n':
                        show = "\\n";
                        break;
                    case '\r':
                        show = "\\r";
                        break;
                    case '\v':
                        show = "\\v";
                        break;
                    case '\f':
                        show = "\\f";
                        break;
                }
            }
            else if (char.IsControl(c))
            {
                show = "control";
            }
            else
            {
                show = c.ToString();
            }

            // Fill table
            Console.Write(i.ToString().PadRight(10));
            Console.Write(i.ToString("X").PadRight(10));
            Console.Write(show);
            Console.WriteLine();
        }
    }
}