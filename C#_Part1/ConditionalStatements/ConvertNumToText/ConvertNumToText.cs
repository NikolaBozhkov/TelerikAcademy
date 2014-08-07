// * Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
// 0  "Zero"
// 273  "Two hundred seventy three"
// 400  "Four hundred"
// 501  "Five hundred and one"
// 711  "Seven hundred and eleven"

using System;
using System.Collections.Generic;

public class ConvertNumToText
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter a number you want to convert to text(from 0 to 999): ");
            string line = Console.ReadLine();
            int num;
            List<string> digits = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            List<string> teens = new List<string> { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            List<string> fulls = new List<string> { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            if (int.TryParse(line, out num) && num > -1 && num < 1000)
            {
                if (num == 0)
                {
                    Console.WriteLine("Zero");
                }
                else if (num < 10)
                {
                    Console.WriteLine(UppercaseFirst(digits[num - 1]));
                }
                else if (num > 10 && num < 20)
                {
                    Console.WriteLine(UppercaseFirst(teens[num - 11]));
                }
                else if (num < 100)
                {
                    if (num % 10 == 0)
                    {
                        Console.WriteLine(UppercaseFirst(fulls[(num / 10) - 1]));
                    }
                    else
                    {
                        Console.WriteLine(UppercaseFirst(fulls[(num / 10) - 1]) + " " + digits[(num % 10) - 1]);
                    }
                }
                else
                {
                    if (num % 100 == 0)
                    {
                        Console.WriteLine(UppercaseFirst(digits[(num / 100) - 1]) + " hundred");
                    }
                    else if (num % 10 == 0)
                    {
                        Console.WriteLine(UppercaseFirst(digits[(num / 100) - 1]) + " hundred and " + fulls[((num % 100) / 10) - 1]);
                    }
                    else if (num % 100 > 0 && num % 100 < 10)
                    {
                        Console.WriteLine(UppercaseFirst(digits[(num / 100) - 1]) + " hundred and " + digits[(num % 10) - 1]);
                    }
                    else if (num % 100 > 10 && num % 100 < 20)
                    {
                        Console.WriteLine(UppercaseFirst(digits[(num / 100) - 1]) + " hundred and " + teens[(num % 100) - 11]);
                    }
                    else
                    {
                        Console.WriteLine(UppercaseFirst(digits[(num / 100) - 1]) + " hundred " + fulls[((num % 100) / 10) - 1] + " " + digits[(num % 10) - 1]);
                    }               
                }

                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }       
    }

    private static string UppercaseFirst(string s)
    {
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
}