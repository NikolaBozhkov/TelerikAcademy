// You are given a sequence of positive integer values written into a string, separated by spaces.
// Write a function that reads these values from given string and calculates their sum. Example:
// string = "43 68 9 23 318"  result = 461

using System;

public class SumOfNums
{
    public static int SumFromString(string nums)
    {
        int sum = 0;
        string[] separatedNums = nums.Split();
        foreach (string num in separatedNums)
        {
            sum += int.Parse(num);
        }

        return sum;
    }

    public static void Main()
    {
        Console.Write("Enter the numbers you want the sum of: ");
        string nums = Console.ReadLine();
        Console.WriteLine("The sum of {0} is: {1}", nums, SumFromString(nums));
    }
}