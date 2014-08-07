// Write a program that finds the maximal sequence of equal elements in an array.
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;
using System.Collections.Generic;

public class FindMaxSequenceOfElem
{
    public static void Main()
    {
        Console.Write("Enter the lenght of the array: ");
        int lenght = int.Parse(Console.ReadLine());
        int[] array = new int[lenght];
        List<int> sequence = new List<int>();
        List<int> backupSequence = new List<int>();
        int count = 0;
        int backupCount = 0;
        Console.WriteLine("Enter the elements of the array(each on separate line): ");
        for (int i = 0; i < lenght; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }   
    
        for (int i = 1; i < lenght; i++)
        {
            // Check elements
            if (array[i] == array[i - 1])
            {
                count++;

                // We do not check i = 0, so we add it with if statement
                if (i == 1)
                {
                    count++;
                    sequence.Add(array[0]);                   
                }

                sequence.Add(array[i]);                             
            }
            else
            {
                // If the new seq is longer than the previous one
                if (sequence.Count > backupSequence.Count)
                {
                    backupCount = count;
                    count = 1;
                    backupSequence.Clear();
                    backupSequence.AddRange(sequence);
                    sequence.Clear();
                }
                else
                {
                    count = 1;
                    sequence.Clear();
                }

                // Adding first element in the new seq
                sequence.Add(array[i]);
            }
        }

        // If there is a longer sequence but the for cycle ended before it can be checked
        if (sequence.Count > backupSequence.Count)
        {
            Console.WriteLine("The longest sequence is {0} elements long", count);
            foreach (var item in sequence)
            {
                Console.Write("{0}, ", item);
            }
        }
        else
        {
            Console.WriteLine("The longest sequence is {0} elements long", backupCount);
            foreach (var item in backupSequence)
            {
                Console.Write("{0} ", item);
            }
        }

        Console.WriteLine();
    }
}