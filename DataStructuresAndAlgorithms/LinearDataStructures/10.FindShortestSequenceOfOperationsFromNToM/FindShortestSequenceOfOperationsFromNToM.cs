namespace FindShortestSequenceOfOperationsFromNToM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FindShortestSequenceOfOperationsFromNToM
    {
        public static void Main()
        {
            int n = 5;
            int m = 64;
            int treshold = 3;

            var sequence = new Queue<int>();
            sequence.Enqueue(n);

            var current = sequence.Dequeue();
            int level = 0;
            int enquedForNow = 0;
            Console.WriteLine("{0}{1}", new string('-', level * 3), current);

            while (current != m)
            {
                sequence.Enqueue(current + 1);
                sequence.Enqueue(current + 2);
                sequence.Enqueue(current * 2);

                enquedForNow += 3;
                if (enquedForNow == treshold)
                {
                    level++;
                    treshold *= 3;
                    enquedForNow = 0;
                }

                current = sequence.Dequeue();
                Console.WriteLine("{0}{1}", new string('-', level * 3), current);
            }

            Console.WriteLine("{0} -> {1} is reached with {2} operations", n, m, level);
        }
    }
}
