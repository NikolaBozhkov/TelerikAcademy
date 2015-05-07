namespace InvalidRangeExceptionTask
{
    using System;

    public class Sample
    {
        // I didn't get that exception, seems pretty useless
        // Lots of code for almost nothing...
        static void Main()
        {
            //InvalidRangeException<int> example
            PrintConsoleNumber();

            Console.WriteLine();

            //InvalidRangeException<DateTime> example
            PrintConsoleDateTime();
        }

        private static void PrintConsoleNumber()
        {
            const int MinNumber = 0;
            const int MaxNumber = 100;

            Console.Write("Insert number [{0}:{1}]: ", MinNumber, MaxNumber);

            try
            {
                Console.WriteLine("Inserted number: " + GetConsoleNumber(MinNumber, MaxNumber));
            }
            catch (InvalidRangeException<int> invalidRangeEx)
            {
                Console.WriteLine("<!> InvalidRangeException catched:");
                Console.WriteLine("Number {0} is not in the defined range of [{1}:{2}].",
                invalidRangeEx.Value, invalidRangeEx.Start, invalidRangeEx.End);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error occured.");
            }
        }

        public static int GetConsoleNumber(int min, int max)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < min || number > max)
            {
                throw new InvalidRangeException<int>("Number is not in range.", number, min, max);
            }

            return number;
        }

        private static void PrintConsoleDateTime()
        {
            var minDate = new DateTime(1980, 1, 1);
            var maxDate = new DateTime(2013, 12, 31);

            Console.Write("Insert date [{0}, {1}]: ", minDate.ToShortDateString(), maxDate.ToShortDateString());

            try
            {
                Console.WriteLine("Inserted date: " + GetConsoleDateTime(minDate, maxDate));
            }
            catch (InvalidRangeException<DateTime> invalidRangeEx)
            {
                Console.WriteLine("<!> InvalidRangeException catched:");
                Console.WriteLine("DateTime {0} is not in the defined range of [{1}:{2}].",
                invalidRangeEx.Value.ToShortDateString(), invalidRangeEx.Start.ToShortDateString(),
                invalidRangeEx.End.ToShortDateString());
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error occured.");
            }
        }

        private static DateTime GetConsoleDateTime(DateTime min, DateTime max)
        {
            DateTime date = DateTime.Parse(Console.ReadLine());

            if (date < min || date > max)
            {
                throw new InvalidRangeException<DateTime>("Date is not in range.", date, min, max);
            }

            return date;
        }
    }
}