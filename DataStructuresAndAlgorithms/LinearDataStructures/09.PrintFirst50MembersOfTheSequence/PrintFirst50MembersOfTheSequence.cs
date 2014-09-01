namespace PrintFirst50MembersOfTheSequence
{
    using System;
    using System.Collections.Generic;

    public class PrintFirst50MembersOfTheSequence
    {
        public static void Main()
        {
            var n = 2;
            var sequence = new Queue<int>();

            sequence.Enqueue(n);
            var index = 0;

            while (index < 50)
            {
                var current = sequence.Dequeue();
                Console.WriteLine(current);

                sequence.Enqueue(current + 1);
                sequence.Enqueue(current * 2 + 1);
                sequence.Enqueue(current + 2);

                index++;
            }            
        }
    }
}
