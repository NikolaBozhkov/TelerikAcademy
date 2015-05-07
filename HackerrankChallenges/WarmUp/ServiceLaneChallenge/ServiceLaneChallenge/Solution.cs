namespace ServiceLaneChallenge
{
    using System;
    using System.Linq;

    public class Solution
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            int[] input = GetInputAsIntArray();

            int freewayLength = input[0];
            int tests = input[1];

            int[] width = GetInputAsIntArray();

            PerformTests(tests, freewayLength, width);
        }

        public static void PerformTests(int tests, int freewayLength, int[] width)
        {
            for (int i = 0; i < tests; i++)
            {
                int[] input = GetInputAsIntArray();

                Console.WriteLine(TestVechicle(width, input[0], input[1]));
            }
        }

        public static int TestVechicle(int[] width, int entry, int exit)
        {
            int result = 3;

            for (int current = entry; current <= exit; current++)
            {
                if (width[current] < result)
                {
                    result = width[current];
                }
            }

            return result;
        }

        public static int[] GetInputAsIntArray()
        {
            return Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        }
    }
}