// Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".

using System;

public class LastDigitAsWordMethod
{
    public static string LastDigitAsWord(int number)
    {
        string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int digit = number % 10;
        return digitsArr[digit];
    } 
    
    // Not much to comment
    public static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("The last digit of {0} is {1}", num, LastDigitAsWord(num));
    }
}