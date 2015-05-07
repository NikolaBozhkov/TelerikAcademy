namespace ComparePerformanceOfNumericActions
{
    public static class DivisionMethods
    {
        public static void TestIntDivision()
        {
            int res = 0;

            for (int i = 1; i <= 1000000; i++)
            {
                res /= i;
            }
        }

        public static void TestLongDivision()
        {
            long res = 0;

            for (long i = 1; i <= 1000000; i++)
            {
                res /= i;
            }
        }

        public static void TestFloatDivision()
        {
            float res = 0;

            for (float i = 1; i <= 1000000; i++)
            {
                res /= i;
            }
        }

        public static void TestDoubleDivision()
        {
            double res = 0;

            for (double i = 1; i <= 1000000; i++)
            {
                res /= i;
            }
        }

        public static void TestDecimalDivision()
        {
            decimal res = 0;

            for (decimal i = 1; i <= 1000000; i++)
            {
                res /= i;
            }
        }
    }
}
