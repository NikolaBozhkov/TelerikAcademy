namespace ComparePerformanceOfNumericActions
{
    public static class IncrementationMethods
    {
        public static void TestIntIncrementation()
        {
            int res = 0;

            for (int i = 0; i < 1000000; i++)
            {
                res++;
            }
        }

        public static void TestLongIncrementation()
        {
            long res = 0;

            for (long i = 0; i < 1000000; i++)
            {
                res++;
            }
        }

        public static void TestFloatIncrementation()
        {
            float res = 0;

            for (float i = 0; i < 1000000; i++)
            {
                res++;
            }
        }

        public static void TestDoubleIncrementation()
        {
            double res = 0;

            for (double i = 0; i < 1000000; i++)
            {
                res++;
            }
        }

        public static void TestDecimalIncrementation()
        {
            decimal res = 0;

            for (decimal i = 0; i < 1000000; i++)
            {
                res++;
            }
        }
    }
}
