namespace ComparePerformanceOfSquareLogSinus
{
    using System;

    public static class SquareRootMethods
    {
        public static void TestFloatSquareRoot()
        {
            for (float i = 0; i < 1000000; i++)
            {
                Math.Sqrt(i);
            }
        }

        public static void TestDoubleSquareRoot()
        {
            for (double i = 0; i < 1000000; i++)
            {
                Math.Sqrt(i);
            }
        }

        public static void TestDecimalSquareRoot()
        {
            for (decimal i = 0; i < 1000000; i++)
            {
                Math.Sqrt((double)i);
            }
        }
    }
}