// Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

public class CheckDivisionBy7And5
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter an integer: ");
            string line = Console.ReadLine();
            int num;
            if (int.TryParse(line, out num))
            {
                bool check = (num % 7 == 0 && num % 5 == 0);
                Console.WriteLine("The integer can be divided by 7 and 5 at the same time: " + check);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
