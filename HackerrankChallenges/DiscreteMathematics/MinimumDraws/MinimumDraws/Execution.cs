namespace MinimumDraws
{
    using System;

    public class Execution
    {
        public static void Main()
        {
            Execution.Run();
        }

        public static void Run()
        {
            int tests = int.Parse(Console.ReadLine());

            for (int i = 0; i < tests; i++)
            {
                int pairs = int.Parse(Console.ReadLine());

                Console.WriteLine(pairs + 1);
            }
        }
    }
}