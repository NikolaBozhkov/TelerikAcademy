// Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

using System;

public class CheckThirdDigit
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter an integer: ");
            string line = Console.ReadLine();
            int num;
            if (int.TryParse(line, out num))
            {
                int preResult = num / 100;
                int result = preResult % 10;
                Console.WriteLine(result == 7);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}