namespace RemoveNumbersThatOccurOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNumbersThatOccurOddNumberOfTimes
    {
        public static void Main()
        {
            var sequence = new List<int>
            {
                1, 1, 2, 3, 3, 2, 3, 4, 4, 5, 6, 6, 6, 6, 7
            };

            var distinctNumbers = sequence.Distinct().ToList();

            foreach (var number in distinctNumbers)
            {
                var sequenceOfSameNumbers = sequence.FindAll(x => x == number);
                sequence.RemoveAll(x => sequenceOfSameNumbers.Count % 2 != 0 && x == number);
            }

            Console.WriteLine("Only even times occuring numbers -> [{0}]", string.Join(", ", sequence));
        }
    }
}
