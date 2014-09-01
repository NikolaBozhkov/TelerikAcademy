namespace ReverseSequenceWithStack
{
    using System;
    using System.Collections.Generic;

    public class ReverseSequenceUsingStack
    {
        public static void Main()
        {
            var integers = new Stack<int>();

            Console.Write("Number of ints: ");
            var numberOfInts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInts; i++)
            {
                integers.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Reversed:");
            while (integers.Count != 0)
            {
                Console.WriteLine(integers.Pop());
            }
        }
    }
}
