// Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
// Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;
using System.Text;

public class AddIntsRepByArr
{
    public static string AddIntByArr(int[] firstNumber, int[] secondNumber)
    {
        StringBuilder result = new StringBuilder();
        List<int> sum = new List<int>(); // Work place
        int index = 0;
        int onMind = 0;

        // Loop trought all
        while (index < firstNumber.Length || index < secondNumber.Length)
        {
            // Ifs, for handling IndexOutOfRangeExeption
            if (firstNumber.Length == index && secondNumber.Length > index)
            {
                sum.Add(secondNumber[index] + onMind);

                // Add the rest of the elements
                for (int i = index + 1; i < secondNumber.Length; i++)
                {
                    sum.Add(secondNumber[i]);
                }

                break;
            }
            else if (firstNumber.Length > index && secondNumber.Length == index)
            {
                // Same as above
                sum.Add(firstNumber[index] + onMind);
                for (int elem = index + 1; elem < firstNumber.Length; elem++)
                {
                    sum.Add(firstNumber[elem]);
                }

                break;
            }

            int digitsSum = firstNumber[index] + secondNumber[index];
            int write = digitsSum % 10;
            sum.Add(write + onMind); // Adding the new digit + the digit on mind(if we have one)            
            onMind = digitsSum / 10;

            // Extra check if there is 1 more digit to add(55 + 55 = 110)
            if (firstNumber.Length - 1 == index && secondNumber.Length - 1 == index && onMind == 1)
            {
                sum.Add(onMind);
            }

            index++;
        }

        // Reverse filling our result string
        for (int elem = sum.Count - 1; elem >= 0; elem--)
        {
            result.Append(sum[elem]);
        }

        return result.ToString();
    }

    public static void Main()
    {
        // Just tests
        int[] testNumber1 = new int[10000];
        int[] testNumber2 = new int[10000];
        for (int i = 0; i < testNumber1.Length; i++)
        {
            testNumber1[i] = 1;
        }

        for (int i = 0; i < testNumber2.Length; i++)
        {
            testNumber2[i] = 2;
        }

        string result = AddIntByArr(testNumber1, testNumber2);
        Console.WriteLine(result);
    }
}