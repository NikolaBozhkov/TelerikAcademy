// Write a program to calculate n! for each n in the range [1..100].
// Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Collections.Generic;

public class CalcFactFor1To100
{
    public static List<int> MultiplicationByArray(int multiplier, List<int> array)
    {
        array.Reverse(); // Reverse to get the array ready for work
        List<int> listResult = new List<int>();
        int onMind = 0;

        // Multiplying digit by digit
        for (int i = 0; i < array.Count; i++)
        {
            int preWrite = array[i] * multiplier; // The multiplication of the digit
            int write = (preWrite + onMind) % 10; // Getting the digit we want to write
            listResult.Add(write);
            onMind = (preWrite + onMind) / 10; // Getting the number on mind from the multiplication

            // Check if there is a number on mind from the last multiplication
            if (onMind > 0 && i == array.Count - 1)
            {
                string writeOnMind = onMind.ToString();

                // Adding each digit from the number on mind to the new number
                for (int index = writeOnMind.Length - 1; index >= 0; index--)
                {
                    int writeDigit = int.Parse(writeOnMind[index].ToString());
                    listResult.Add(writeDigit);
                }
            }
        }

        listResult.Reverse(); // The number in normal order
        return listResult;
    }

    public static void Main()
    {
        List<int> fact = new List<int> { 1 };
        for (int i = 1; i <= 100; i++)
        {
            fact = MultiplicationByArray(i, fact);
            Console.Write("{0}! = ", i);
            for (int digit = 0; digit < fact.Count; digit++)
            {
                Console.Write(fact[digit]);
            }

            Console.WriteLine("\n");
        }
    }
}