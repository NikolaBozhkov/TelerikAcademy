namespace SherlockAndBeast
{
    using System;
    using System.Text;

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
                int input = int.Parse(Console.ReadLine());

                Console.WriteLine(Execution.FindNumber(input));
            }
        }

        public static string FindNumber(int numOfDigits)
        {
            const string Fives = "555";
            const string Threes = "33333";
            StringBuilder result = new StringBuilder(numOfDigits);

            while (numOfDigits != 0)
            {
                if (numOfDigits < 0)
                {
                    return "-1";
                }
                else if (numOfDigits % 5 == 0 && !Execution.ContinueAddingFives(numOfDigits))
                {
                    Execution.AppendDigits(ref result, numOfDigits / 5, Threes);
                    numOfDigits = 0;
                }
                else
                {
                    numOfDigits -= 3;
                    result.Append(Fives);
                }
            }

            return result.ToString();
        }

        public static void AppendDigits(ref StringBuilder result, int times, string value)
        {
            for (int i = 0; i < times; i++)
            {
                result.Append(value);
            }
        }

        public static bool ContinueAddingFives(int numOfDigits)
        {
            while (numOfDigits > 0)
            {
                numOfDigits -= 3;
                if (numOfDigits % 5 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}