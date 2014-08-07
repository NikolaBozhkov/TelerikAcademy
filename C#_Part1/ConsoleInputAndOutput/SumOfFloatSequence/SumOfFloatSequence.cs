// Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

public class SumOfFloatSequence
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter to which integer you want to calculate(1 + 1/2 - 1/3 + 1/4 - 1/5 + ... +- 1/x): ");
            string line = Console.ReadLine();
            int num;
            decimal result = 1m;
            if (int.TryParse(line, out num) && num > 1)
            {
                for (int i = 2; i <= num; i++)
                {
                    if (i % 2 == 0)
                    {
                        result += 1m / i;
                    }
                    else
                    {
                        result -= 1m / i;
                    }
                }

                Console.WriteLine("The result is: {0:0.000}", result);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}