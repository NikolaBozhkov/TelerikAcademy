using System;

namespace Methods
{
    public class Methods
    {
        static string DigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Argument must be digit.");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Array of elements cannot be empty or null.");
            }

            int max = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                int current = elements[i];
                if (current > max)
                {
                    max = current;
                }
            }

            return max;
        }

        // Not sure how to rewrite this because of the object ?!
        static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        static void Main()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine(triangle.CalculateArea());
            
            Console.WriteLine(DigitToWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Line line = new Line(new Point(3, -1), new Point(3, 2.5));
            Console.WriteLine(line.Length);

            bool horizontal = line.IsHorizontal();
            bool vertical = line.IsVertical();
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Sofia");

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "Vidin");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
