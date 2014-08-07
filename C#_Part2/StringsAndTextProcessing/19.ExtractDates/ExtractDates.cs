// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
// Display them in the standard date format for Canada.

using System;
using System.Text.RegularExpressions;
using System.Globalization;

public class ExtractDates
{
    public static void Main()
    {
        string str = "On 30.12.2006 more dates 03.01.2013 and more dates 09.11.2001 and two wrong 9.13.2001, 11.11.0155";

        foreach (var match in Regex.Matches(str, @"\b([0-2][0-9]|3[0-1])\.(0[1-9]|1[0-2])\.[1-9][0-9]{3}\b"))
        {
            string s = match.ToString();
            DateTime date = DateTime.ParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.ToString(new CultureInfo("en-CA")));
        }
    }
}