namespace ComparePerformanceOfNumericActions
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    public class ComparePerformanceOfNumericActions
    {
        public static void Main()
        {
            Console.WriteLine("Results are displayed in miliseconds!");
            Console.WriteLine(new string('-', 50));

            Console.Write("Addition for integer: ");
            DisplayExecutionTime(AdditionMethods.TestIntAddition);

            Console.Write("Addition for long: ");
            DisplayExecutionTime(AdditionMethods.TestLongAddition);

            Console.Write("Addition for float: ");
            DisplayExecutionTime(AdditionMethods.TestFloatAddition);

            Console.Write("Addition for double: ");
            DisplayExecutionTime(AdditionMethods.TestDoubleAddition);

            Console.Write("Addition for decimal: ");
            DisplayExecutionTime(AdditionMethods.TestDecimalAddition);

            Console.WriteLine(new string('-', 50));

            Console.Write("Subtraction for integer: ");
            DisplayExecutionTime(SubtractionMethods.TestIntSubtraction);

            Console.Write("Subtraction for long: ");
            DisplayExecutionTime(SubtractionMethods.TestLongSubtraction);

            Console.Write("Subtraction for float: ");
            DisplayExecutionTime(SubtractionMethods.TestFloatSubtraction);

            Console.Write("Subtraction for double: ");
            DisplayExecutionTime(SubtractionMethods.TestDoubleSubtraction);

            Console.Write("Subtraction for decimal: ");
            DisplayExecutionTime(SubtractionMethods.TestDecimalSubtraction);

            Console.WriteLine(new string('-', 50));

            Console.Write("Incrementation for integer: ");
            DisplayExecutionTime(IncrementationMethods.TestIntIncrementation);

            Console.Write("Incrementation for long: ");
            DisplayExecutionTime(IncrementationMethods.TestLongIncrementation);

            Console.Write("Incrementation for float: ");
            DisplayExecutionTime(IncrementationMethods.TestFloatIncrementation);

            Console.Write("Incrementation for double: ");
            DisplayExecutionTime(IncrementationMethods.TestDoubleIncrementation);

            Console.Write("Incrementation for decimal: ");
            DisplayExecutionTime(IncrementationMethods.TestDecimalIncrementation);

            Console.WriteLine(new string('-', 50));

            Console.Write("Multiplication for integer: ");
            DisplayExecutionTime(MultiplicationMethods.TestIntMultiplication);

            Console.Write("Multiplication for long: ");
            DisplayExecutionTime(MultiplicationMethods.TestLongMultiplication);

            Console.Write("Multiplication for float: ");
            DisplayExecutionTime(MultiplicationMethods.TestFloatMultiplication);

            Console.Write("Multiplication for double: ");
            DisplayExecutionTime(MultiplicationMethods.TestDoubleMultiplication);

            Console.Write("Multiplication for decimal: ");
            DisplayExecutionTime(MultiplicationMethods.TestDecimalMultiplication);

            Console.WriteLine(new string('-', 50));

            Console.Write("Division for integer: ");
            DisplayExecutionTime(DivisionMethods.TestIntDivision);

            Console.Write("Division for long: ");
            DisplayExecutionTime(DivisionMethods.TestLongDivision);

            Console.Write("Division for float: ");
            DisplayExecutionTime(DivisionMethods.TestFloatDivision);

            Console.Write("Division for double: ");
            DisplayExecutionTime(DivisionMethods.TestDoubleDivision);

            Console.Write("Division for decimal: ");
            DisplayExecutionTime(DivisionMethods.TestDecimalDivision);

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