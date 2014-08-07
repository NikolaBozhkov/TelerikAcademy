// * Write a program that reads three integer numbers N, K and S and an array of N elements from the console. Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;
using System.Text;

public class SumFromGivenElemNum
{
    public static void Main()
    {
        // I am using the same solution of the problem, just with check for the number of elements k
        int[] array = new int[] { 1, 4, 2, 8, 12, 7, -3, 3, 9, 4, 5 };
        StringBuilder subset = new StringBuilder();
        int currentSum = 0;
        int currentK = 0;
        bool goalAchieved = false;
        ////Console.Write("Enter the numbre of elements N: ");
        ////int numOfElements = int.Parse(Console.ReadLine());
        ////int[] array = new int[numOfElements];
        ////for (int i = 0; i < numOfElements; i++)
        ////{
        ////    Console.Write("Enter element number {0}", i + 1);
        ////    array[i] = int.Parse(Console.ReadLine());
        ////}

        Console.Write("Enter the sum S, you are seeking: ");
        int goal = int.Parse(Console.ReadLine());
        Console.Write("Enter by how many elements you want the sum formed: ");
        int k = int.Parse(Console.ReadLine());

        // Find the max combinations and go through all
        int combinations = (int)Math.Pow(2, array.Length) - 1;
        for (int i = 1; i <= combinations; i++)
        {
            subset.Clear();
            currentSum = 0;
            currentK = 0;
            
            for (int j = 1; j <= array.Length; j++)
            {
                if (((i >> (j - 1)) & 1) == 1)
                {
                    currentK++;
                    currentSum += array[j - 1];
                    subset.AppendFormat("{0} + ", array[j - 1]);
                }
            }

            if (currentSum == goal && currentK == k)
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