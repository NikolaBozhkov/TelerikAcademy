// Write a program that finds in given array of integers a sequence of given sum S (if present). Example:    {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

using System;
using System.Text;

public class FindSeqOfGivenSum
{
    public static void Main()
    {
        int currentSum = 0;
        bool goalAch = false;
        string result = string.Empty;
        StringBuilder seq = new StringBuilder();
        Console.Write("Enter the lenght of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];        
        for (int i = 0; i < length; i++)
        {
            Console.Write("\nEnter element number {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the sum you are seeking: ");
        int goal = int.Parse(Console.ReadLine());

        // Nested fors to make sure that every possible sequence is covered
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < length; j++)
            {
                if (currentSum < goal)
                {
                    currentSum += array[j];
                    seq.Append(array[j] + " ");
                }
                else if (currentSum > goal)
                {
                    currentSum = array[j - 1] + array[j];
                    seq.Clear();
                    seq.Append(array[j - 1] + " " + array[j] + " ");
                }
                else
                {
                    goalAch = true;
                    result = seq.ToString();
                }
            }
        }        

        if (goalAch)
        {
            Console.WriteLine("The sequence that gives the wanted sum is: [ {0}]", result);
        }
        else
        {
            Console.WriteLine("There is no sequence that gives the wanted sum in this array.");
        }
    }
}