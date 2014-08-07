// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;
using System.Globalization;

public class DaysBetweenDates
{
    public static void Main()
    {
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        double distance = (firstDate - secondDate).TotalDays;

        // Always get positive result
        if (distance < 0)
        {
            distance *= -1;
        }

        Console.WriteLine("First date: {0}\nSecond date: {1}\nDistance: {2}", firstDate, secondDate, distance);
    }
}