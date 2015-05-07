namespace CorrectUseOfVarsDataExprConst
{
    using System;

    public class PrintStatisticsClass
    {
        public static void Main()
        {
            double[] numbers = { 1, 2, 3, 4, 5 };
            PrintStatistics(numbers, 5);
        }

        public static void PrintStatistics(double[] numbers, int count)
        {
            double max = GetMax(numbers, count);
            double min = GetMin(numbers, count);
            double average = GetAverage(numbers, count);

            PrintMax(max);
            PrintMin(min);
            PrintAverage(average);
        }

        private static double GetMax(double[] numbers, int count)
        {
            double max = double.MinValue;

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private static double GetMin(double[] numbers, int count)
        {
            double min = double.MaxValue;

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private static double GetAverage(double[] numbers, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += numbers[i];
            }

            double average = sum / count;
            return average;
        }

        private static void PrintMax(double max)
        {
            Console.WriteLine("The maximum is: {0}", max);
        }

        private static void PrintMin(double min)
        {
            Console.WriteLine("The minimum is: {0}", min);
        }

        private static void PrintAverage(double average)
        {
            Console.WriteLine("The average is: {0}", average);
        }
    }
}