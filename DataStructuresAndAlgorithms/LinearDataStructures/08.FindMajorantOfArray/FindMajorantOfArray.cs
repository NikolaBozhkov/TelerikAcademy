namespace FindMajorantOfArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindMajorantOfArray
    {
        public static void Main()
        {
            var numbers = new List<int>() 
            {
                1, 2, 3, 3, 3, 3, 3, 4, 4
            };

            var found = false;
            var distict = numbers.Distinct();

            foreach (var number in distict)
            {
                var occurencesOfNumber = numbers.FindAll(x => x == number).Count;
                if (occurencesOfNumber >= numbers.Count / 2 + 1)
                {
                    Console.WriteLine("[{0}] -> {1}", string.Join(", ", numbers), number);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("[{0}] -> none", string.Join(", ", numbers));
            }
        }
    }
}
