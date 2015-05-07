namespace ComparePerformanceOfSquareLogSinus
{
    using System;

    public static class SinusMethods
    {
        public static void TestFloatSinus()
        {
            for (float i = 0; i < 1000000; i++)
            {
                Math.Sin(i);
            }
        }

        public static void TestDoubleSinus()
        {
            for (double i = 0; i < 1000000; i++)
            {
                Math.Sin(i);
            }
        }

        public static void TestDecimalSinus()
        {
            for (decimal i = 0; i < 1000000; i++)
            {
                Math.Sin((double)i);
            }
        }
    }
}
