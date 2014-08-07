// Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

using System;

public class SumNNumbers
{
    public static void Main()
    {
        int n;
        int sum = 0;
        Console.Write("Enter how many numbers you want to sum up: ");
        while (true)
        {
            string lineN = Console.ReadLine();
            if (int.TryParse(lineN, out n))
            {
                Console.WriteLine("Enter the numbers you want to sum up(after each hit enter): ");
                for (int i = 0; i < n; i++)
                {
                    while (true)
                    {
                        int num;
                        string lineNum = Console.ReadLine();
                        if (int.TryParse(lineNum, out num))
                        {
                            sum += num;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                }

                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        Console.WriteLine("The sum is {0}", sum);
    }
}
