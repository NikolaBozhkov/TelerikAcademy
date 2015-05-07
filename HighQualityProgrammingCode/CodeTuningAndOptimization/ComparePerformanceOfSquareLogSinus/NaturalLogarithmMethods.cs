namespace ComparePerformanceOfSquareLogSinus
{
    using System;

    public static class NaturalLogarithmMethods
    {
        public static void TestFloatNaturalLogarithm()
        {
            for (float i = 0; i < 1000000; i++)
            {
                Math.Log(i);
            }
        }

        public static void TestDoubleNaturalLogarithm()
        {
            for (double i = 0; i < 1000000; i++)
            {
                Math.Log(i);
            }
        }

        public static void TestDecimalNaturalLogarithm()
        {
            for (decimal i = 0; i < 1000000; i++)
            {
                Math.Log((double)i);
            }
        }
    }
}
