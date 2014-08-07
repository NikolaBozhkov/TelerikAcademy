// Write a program that reads a date and time given in the format: 
// day.month.year hour:minute:second and prints the date and time 
// after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;

public class GetTimeAfter6HAnd30M
{
    public static void Main()
    {
        string str = "12.03.2013 13:50:34";
        string format = "d.MM.yyyy H:mm:ss";
        DateTime date = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
        date = date.AddHours(6.5);
        Console.WriteLine("{0} - {1}", date.ToString(format), date.ToString("dddd", new CultureInfo("bg-BG")));
    }
}