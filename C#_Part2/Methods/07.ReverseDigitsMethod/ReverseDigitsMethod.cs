// Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

public class ReverseDigitsMethod
{
    public static decimal ReverseDigits(decimal number)
    {
        // Converting the input num to string so we can get each digit
        string workNum = number.ToString();
        string newNum = string.Empty;
        for (int i = workNum.Length - 1; i >= 0; i--)
        {
            newNum += workNum[i];
        }

        number = decimal.Parse(newNum);
        return number;
    }

    public static void Main()
    {
        Console.WriteLine(ReverseDigits(-12345));
    }
}