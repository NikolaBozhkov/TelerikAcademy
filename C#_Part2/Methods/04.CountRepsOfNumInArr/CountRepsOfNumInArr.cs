// Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;

public class CountRepsOfNumInArr
{
    public static int CountReps(int number, int[] array)
    {
        int count = 0;

        // Check every element if equal to num
        foreach (int element in array)
        {
            if (element == number)
            {
                count++;
            }
        }

        return count;
    }

    public static void Main()
    {       
    }
}