namespace FindHowManyTimesEachIntOccurs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindHowManyTimesEachIntOccurs
    {
        public static void Main()
        {
            var sequence = new List<int>
            {
                10, 10, 10, 12, 10, 14, 14, 600, 600, 450, 600, 15, 15, 15
            };

            var distinctNumbers = sequence.Distinct().ToList();

            foreach (var number in distinctNumbers)
            {
                var occurenceTimes = sequence.FindAll(x => x == number).Count;
                Console.WriteLine("{0} -> {1} times", number, occurenceTimes);
            }
        }
    }
}