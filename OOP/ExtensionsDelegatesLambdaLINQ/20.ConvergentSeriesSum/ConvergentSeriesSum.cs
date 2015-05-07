using System;

public class ConvergentSeriesSum
{
    public static void Main()
    {
        // 1 + 1/2 + 1/4 + 1/8 + 1/16 + ...
        double first = ConvergentSum(index => 1 / Math.Pow(2, index - 1), 0.01);
        Console.WriteLine(first);

        // 1 + 1/2! + 1/3! + 1/4! + 1/5! + ...
        double second = ConvergentSum(index => 1 / Factorial(index), 0.01);
        Console.WriteLine(second);

        // 1 + 1/2 - 1/4 + 1/8 - 1/16 + ...
        double third = ConvergentSum((index) =>
        {
            double result = 1 / Math.Pow(2, index - 1);
            if (index > 2 && index % 2 != 0)
            {
                result *= -1;
            }

            return result;
        }, 0.01);
        Console.WriteLine(third);
    }

    public static double ConvergentSum(Func<double, double> value, double precision)
    {
        double previousSum = 0;
        double currentSum = 0;
        double counter = 1;
        do
        {
            previousSum = currentSum;
            currentSum = previousSum + value(counter);
            counter++;

        } 
        while (Math.Abs(currentSum - previousSum) >= precision);

        return currentSum;
    }

    public static double Factorial(double index)
    {
        if (index <= 1)
        {
            return 1;
        }
        return index * Factorial(index - 1);
    }
}