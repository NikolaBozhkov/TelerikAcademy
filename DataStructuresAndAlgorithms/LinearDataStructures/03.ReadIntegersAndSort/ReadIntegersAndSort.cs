namespace ReadIntegersAndSort
{
    using System;
    using System.Collections.Generic;

    public class ReadIntegersAndSort
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

            sequence.Sort();
            Console.WriteLine("Sorted: {0}", string.Join(", ", sequence));
        }
    }
}
