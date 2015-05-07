namespace ComparePerformanceOfSquareLogSinus
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    public class ComparePerformanceOfSquareLogSinus
    {
        public static void Main()
        {
            Console.WriteLine(new string('-', 50));

            Console.Write("Square root for float: ");
            DisplayExecutionTime(SquareRootMethods.TestFloatSquareRoot);

            Console.Write("Square root for double: ");
            DisplayExecutionTime(SquareRootMethods.TestDoubleSquareRoot);

            Console.Write("Square root for decimal: ");
            DisplayExecutionTime(SquareRootMethods.TestDecimalSquareRoot);

            Console.WriteLine(new string('-', 50));

            Console.Write("Natural logarithm for float: ");
            DisplayExecutionTime(NaturalLogarithmMethods.TestFloatNaturalLogarithm);

            Console.Write("Natural logarithm for double: ");
            DisplayExecutionTime(NaturalLogarithmMethods.TestDoubleNaturalLogarithm);

            Console.Write("Natural logarithm for decimal: ");
            DisplayExecutionTime(NaturalLogarithmMethods.TestDecimalNaturalLogarithm);

            Console.WriteLine(new string('-', 50));

            Console.Write("Sinus for float: ");
            DisplayExecutionTime(SinusMethods.TestFloatSinus);

            Console.Write("Sinus for double: ");
            DisplayExecutionTime(SinusMethods.TestDoubleSinus);

            Console.Write("Sinus for decimal: ");
            DisplayExecutionTime(SinusMethods.TestDecimalSinus);

            Console.WriteLine(new string('-', 50));
        }

        public static void DisplayExecutionTime(Action action)
        {
            TimeSpan averageTime = new TimeSpan();

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                action();
                stopwatch.Stop();
                averageTime = averageTime.Add(stopwatch.Elapsed);
            }

            double result = averageTime.TotalMilliseconds / 10;

            Console.WriteLine(result);
        }
    }
}