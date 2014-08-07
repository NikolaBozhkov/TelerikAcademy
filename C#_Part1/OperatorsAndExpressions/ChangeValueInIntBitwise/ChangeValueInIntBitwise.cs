// We are given integer number n, value v (v=0 or 1) and a position p.
// Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
// Example: n = 5 (00000101), p=3, v=1  13 (00001101)
// n = 5 (00000101), p=2, v=0  1 (00000001)

using System;

public class ChangeValueInIntBitwise
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter an integer you want to change: ");
            string lineI = Console.ReadLine();
            Console.Write("Please enter the value that you want to use(0 or 1): ");
            string lineV = Console.ReadLine();
            Console.Write("Please enter the position, at which to replace: ");
            string lineP = Console.ReadLine();
            int i;
            int v;
            int p;
            int result;
            int mask = 1;
            if (int.TryParse(lineI, out i) && int.TryParse(lineV, out v) && int.TryParse(lineP, out p))
            {
                if (v == 1)
                {
                    mask <<= p;
                    result = mask | i; 
                }
                else
                {
                     mask <<= p;
                     mask = ~mask;
                     result = mask & i;
                }
                Console.WriteLine("The result is: ");
                Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
                break;
            }           
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}