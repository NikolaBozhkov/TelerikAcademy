// Write a program that extracts from given HTML file its 
// title (if available), and its body text without the HTML tags. 

using System;
using System.Text.RegularExpressions;

public class TitleAndBodyFromHTML
{
    public static void Main()
    {
        string str = "<html> <head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">TelerikAcademy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
        var matchText = Regex.Matches(str, @"(?<=>).*?(?=<)");
        foreach (Match text in matchText)
        {
            // check if we matched a whitespace or null
            if (!string.IsNullOrWhiteSpace(text.Value))
            {
                Console.WriteLine(text);
            }
        }
    }
}