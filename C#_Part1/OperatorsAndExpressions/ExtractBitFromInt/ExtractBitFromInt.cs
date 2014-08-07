// Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

using System;

public class ExtractBitFromInt
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter a integer you want ot extract from: ");
            string lineI = Console.ReadLine();
            Console.Write("Please enter the position: ");
            string lineB = Console.ReadLine();
            int i;
            int b;
            int mask = 1;
            if (int.TryParse(lineI, out i) && int.TryParse(lineB, out b))
            {
                mask <<= b;
                int result = mask & i;
                result >>= b;
                Console.WriteLine("The value at position {0} from the integer {1} is: {2}", b, i, result);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}