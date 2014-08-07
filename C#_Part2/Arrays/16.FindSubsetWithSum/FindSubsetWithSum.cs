// * We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
// arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

using System;
using System.Text;

public class FindSubsetWithSum
{
    public static void Main()
    {
        int[] array = new int[] { 1, 4, 2, 8, 12, 7, -3, 3, 9, 4, 5 };
        StringBuilder subset = new StringBuilder();
        int currentSum = 0;
        bool goalAchieved = false;
        Console.Write("Enter the sum S, you are seeking: ");
        int goal = int.Parse(Console.ReadLine());

        // Find the max combinations and go through all
        int combinations = (int)Math.Pow(2, array.Length) - 1;
        for (int i = 1; i <= combinations; i++)
        {
            subset.Clear();
            currentSum = 0;

            // It's a slow method but I don't know what else to do
            for (int j = 1; j <= array.Length; j++)
            {
                if (((i >> (j - 1)) & 1) == 1)
                {
                    currentSum += array[j - 1];
                    subset.AppendFormat("{0} + ", array[j - 1]);
                }
            }

            if (currentSum == goal)
            {
                goalAchieved = true;
                Console.WriteLine("The subset that gives the sum {0} is:\n{1}", goal, subset.Remove(subset.Length - 3, 3).ToString());
            }
        }

        if (!goalAchieved)
        {
            Console.WriteLine("There is no subset that gives the wanted sum {0}", goal);
        }
    }
}