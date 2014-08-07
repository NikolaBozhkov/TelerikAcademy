// Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

public class CheckPrimeNumber
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter a positive integer number(0 < n <= 100): ");
            string line = Console.ReadLine();
            int num;
            bool prime = true;
            if (int.TryParse(line, out num) && num <= 100 && num > 0)
            {
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Console.WriteLine("The number {0} is prime.", num);
                }
                else
                {
                    Console.WriteLine("The number {0} is not prime.", num);
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}