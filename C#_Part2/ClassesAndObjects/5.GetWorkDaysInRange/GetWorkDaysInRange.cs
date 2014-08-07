// Write a method that calculates the number of workdays between today and given date, passed as parameter. 
// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;

public class GetWorkDaysInRange
{
    public static int GetWorkDays(string endDate)
    {
        // Example holidays in array in the format(mm/dd)
        string[] holidays = { "12/24", "12/25", "1/1", "3/3", "5/25", "8/12" };

        // Parse the date to int, so we can input it
        int day = int.Parse(endDate.Substring(3, 2));
        int month = int.Parse(endDate.Substring(0, 2));
        int year = int.Parse(endDate.Substring(6, 4));
        DateTime today = DateTime.Today;
        DateTime end = new DateTime(year, month, day);
        int count = 0;  
        while (today != end)
        {
            DayOfWeek dayOfWeek = today.DayOfWeek;

            // Get a string date, so it can be checked in the array of holidays
            string date = today.Month.ToString() + "/" + today.Day.ToString();

            // Check if today is Saturday, Sunday or a holiday
            if (dayOfWeek != DayOfWeek.Saturday && dayOfWeek != DayOfWeek.Sunday && Array.IndexOf(holidays, date) < 0)
            {
                count++;
            }

            today = today.AddDays(1); // Simply today++
        }

        return count;
    }

    public static void Main()
    {
        DateTime today = DateTime.Today;
        Console.WriteLine("Today is: {0}", today);
        Console.Write("Enter the end date(mm/dd/yyyy), starting from today: ");
        string date = Console.ReadLine();
        Console.WriteLine("The number of work days from today to {0} is : {1}", date, GetWorkDays(date));
    }
}