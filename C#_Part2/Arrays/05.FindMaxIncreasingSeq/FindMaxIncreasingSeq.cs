// Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

using System;
using System.Collections.Generic;

public class FindMaxIncreasingSeq
{
    public static void Main()
    {
        // The exactly same logic as before we just check if the next element is bigger
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
            // The difference is here !
            if (array[i] > array[i - 1])
            {
                count++;
                if (i == 1)
                {
                    count++;
                    sequence.Add(array[0]);                   
                }

                sequence.Add(array[i]);                             
            }
            else
            {
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

                sequence.Add(array[i]);
            }
        }

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