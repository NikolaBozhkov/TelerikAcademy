namespace RemoveNegativeNumbersFromSequence
{
    using System;
    using System.Collections.Generic;

    public class RemoveNegativeNumbersFromSequence
    {
        public static void Main()
        {
            var sequence = new List<int>
            {
                1, 2, -4, -3, 5, 10, -12, -19, 2, 20, -17
            };

            sequence.RemoveAll(x => x < 0);
            Console.WriteLine("Only positive -> [{0}]", string.Join(", ", sequence));
        }
    }
}
