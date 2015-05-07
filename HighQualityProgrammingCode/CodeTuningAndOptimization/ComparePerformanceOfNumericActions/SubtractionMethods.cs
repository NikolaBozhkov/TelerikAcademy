namespace ComparePerformanceOfNumericActions
{
    public static class SubtractionMethods
    {
        public static void TestIntSubtraction()
        {
            int res = 0;

            for (int i = 0; i < 1000000; i++)
            {
                res -= i;
            }
        }

        public static void TestLongSubtraction()
        {
            long res = 0;

            for (long i = 0; i < 1000000; i++)
            {
                res -= i;
            }
        }

        public static void TestFloatSubtraction()
        {
            float res = 0;

            for (float i = 0; i < 1000000; i++)
            {
                res -= i;
            }
        }

        public static void TestDoubleSubtraction()
        {
            double res = 0;

            for (double i = 0; i < 1000000; i++)
            {
                res -= i;
            }
        }

        public static void TestDecimalSubtraction()
        {
            decimal res = 0;

            for (decimal i = 0; i < 1000000; i++)
            {
                res -= i;
            }
        }
    }
}
