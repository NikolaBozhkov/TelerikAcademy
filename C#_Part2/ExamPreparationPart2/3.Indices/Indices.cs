using System;
using System.Text;
using System.Collections.Generic;

class Indices
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split();
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(numbers[i]);
        }

        StringBuilder result = new StringBuilder();
        int index = 0;
        int start = array[0];
        List<int> visited = new List<int>();
        result.Append(0 + " ");
        visited.Add(0);
        while (true)
        {
            index = array[index];
            if (index >= 0 && index < array.Length)
            {
                if (visited.Contains(index))
                {
                    start = index;
                    StringBuilder cycle = new StringBuilder();
                    cycle.Append("(" + index);
                    for (int i = visited.IndexOf(start) + 1; i < visited.Count; i++)
                    {
                        cycle.Append(" " + visited[i]);
                    }

                    cycle.Append(")");
                    if (result.Length < cycle.Length)
                    {
                        result.Clear();
                        result.Append(cycle.ToString());
                        break;
                    }

                    result.Remove(result.Length - cycle.Length, cycle.Length);
                    result.Append(cycle.ToString());
                    break;
                }
                else
                {
                    result.Append(index + " ");
                    visited.Add(index);
                }
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(result.ToString().Trim());
    }
}