// Write a program for extracting all email addresses from given text.
// All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

public class ExtractEmailAddresses
{
    public static void Main()
    {
        string str = "Email 1: test@abv.bg , second email : test.email@yahoo.co.uk and 1 more(wrong): test.email.EM@a.b";

        // Not much to explain, just at the end we put a limit of minimum 2 chars for domain and host
        foreach (var match in Regex.Matches(str, @"\b[a-zA-Z0-9._]+@[a-z.]{2,}\.[a-z.]{2,}\b"))
        {
            Console.WriteLine(match);
        }
    }
}