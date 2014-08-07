// Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;

public class PrintWhatIsToday
{
    public static void Main()
    {
        // Creating new instance of DateTime
        DateTime date = new DateTime();

        // Setting the date to now
        date = DateTime.Now;
        Console.WriteLine("Today is {0}.", date.DayOfWeek);
    }
}