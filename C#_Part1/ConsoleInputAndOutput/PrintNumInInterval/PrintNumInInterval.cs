// Write a program that reads two positive integer numbers and prints how many numbers p
// exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

public class PrintNumInInterval
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter the 1st positive integer number: ");
            string line1 = Console.ReadLine();
            Console.Write("Please enter the 2nd positive integer number: ");
            string line2 = Console.ReadLine();
            int int1;
            int int2;
            int count = 0;
            if (int.TryParse(line1, out int1) && int.TryParse(line2, out int2) && int1 >= 0 && int2 >= 0)
            {
                if (int1 <= int2)
                {
                    for (int num = int1; num <= int2; num++)
                    {
                        if (num % 5 == 0)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine("p({0},{1}) = {2}", int1, int2, count);
                }
                else
                {
                    for (int num = int2; num <= int1; num++)
                    {
                        if (num % 5 == 0)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine("p({0},{1}) = {2}", int2, int1, count);
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