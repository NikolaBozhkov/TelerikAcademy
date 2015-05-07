namespace UtopianTreeChallenge
{
    using System;

    public class UtopianTree
    {
        public static void Main()
        {
            Run();
        }

        public static int GetLengthAfterNCycles(int cycles)
        {
            int length = 1;

            for (int i = 0; i < cycles; i++)
            {
                if (i % 2 == 0)
                {
                    length *= 2;
                }
                else
                {
                    length++;
                }
            }

            return length;
        }

        public static void Run()
        {
            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                int cycles = int.Parse(Console.ReadLine());

                int length = GetLengthAfterNCycles(cycles);

                Console.WriteLine(length);
            }
        }
    }
}