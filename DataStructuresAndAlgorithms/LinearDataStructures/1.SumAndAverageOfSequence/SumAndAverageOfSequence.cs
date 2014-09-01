namespace SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    public class SumAndAverageOfSequence
    {
        public static void Main()
        {
            var sequence = new List<int>();

            var line = Console.ReadLine();
            while (line != string.Empty)
            {
                sequence.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            var sum = CalculateSum(sequence);
            var average = sum / sequence.Count;
            Console.WriteLine("Sum: {0}\nAverage: {1}", sum, average);
        }

        private static long CalculateSum(IEnumerable<int> sequence)
        {
            long sum = 0;

            foreach (var number in sequence)
            {
                sum += number;
            }

            return sum;
        }
    }
}