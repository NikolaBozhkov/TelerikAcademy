namespace ComparePerformanceOfNumericActions
{
    public static class MultiplicationMethods
    {
        public static void TestIntMultiplication()
        {
            int res = 0;

            for (int i = 1; i <= 1000000; i++)
            {
                res *= i;
            }
        }

        public static void TestLongMultiplication()
        {
            long res = 0;

            for (long i = 1; i <= 1000000; i++)
            {
                res *= i;
            }
        }

        public static void TestFloatMultiplication()
        {
            float res = 0;

            for (float i = 1; i <= 1000000; i++)
            {
                res *= i;
            }
        }

        public static void TestDoubleMultiplication()
        {
            double res = 0;

            for (double i = 1; i <= 1000000; i++)
            {
                res *= i;
            }
        }

        public static void TestDecimalMultiplication()
        {
            decimal res = 0;

            for (decimal i = 1; i <= 1000000; i++)
            {
                res *= i;
            }
        }
    }
}
