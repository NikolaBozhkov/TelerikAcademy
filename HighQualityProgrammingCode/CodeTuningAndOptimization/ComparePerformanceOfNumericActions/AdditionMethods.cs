namespace ComparePerformanceOfNumericActions
{
    public static class AdditionMethods
    {
        public static void TestIntAddition()
        {
            int res = 0;

            for (int i = 0; i < 1000000; i++)
            {
                res += i;
            }
        }

        public static void TestLongAddition()
        {
            long res = 0;

            for (long i = 0; i < 1000000; i++)
            {
                res += i;
            }
        }

        public static void TestFloatAddition()
        {
            float res = 0;

            for (float i = 0; i < 1000000; i++)
            {
                res += i;
            }
        }

        public static void TestDoubleAddition()
        {
            double res = 0;

            for (double i = 0; i < 1000000; i++)
            {
                res += i;
            }
        }

        public static void TestDecimalAddition()
        {
            decimal res = 0;

            for (decimal i = 0; i < 1000000; i++)
            {
                res += i;
            }
        }
    }
}