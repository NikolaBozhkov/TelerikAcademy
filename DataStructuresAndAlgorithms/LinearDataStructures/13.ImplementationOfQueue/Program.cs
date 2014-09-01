namespace ImplementationOfQueue
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 15; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
