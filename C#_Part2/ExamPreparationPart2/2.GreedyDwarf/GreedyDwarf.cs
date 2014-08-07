using System;
using System.Collections.Generic;

class GreedyDwarf
{
    static void Main()
    {
        string nums = Console.ReadLine();
        int mPat = int.Parse(Console.ReadLine());

        int[][] patterns = new int[mPat][];

        for (int i = 0; i < mPat; i++)
        {
            string pattern = Console.ReadLine();
            string[] temp = pattern.Split(new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            patterns[i] = new int[temp.Length];

            for (int j = 0; j < temp.Length; j++)
            {
                patterns[i][j] = int.Parse(temp[j]);
            }
        }

        string[] strValley = nums.Split(new char[] { ',', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        int[] valley = new int[strValley.Length];

        for (int i = 0; i < valley.Length; i++)
        {
            valley[i] = int.Parse(strValley[i]);
        }

        int current = 0;
        int max = int.MinValue;
        List<int> visited = new List<int>();

        for (int i = 0; i < mPat; i++)
        {
            visited.Clear();
            current = 0;
            for (int j = -1, index = 0; true; j++, index += patterns[i][j])
            {
                if (visited.Contains(index) || index < 0 || index >= valley.Length)
                {
                    break;
                }
                if (j == patterns[i].Length - 1)
                {
                    j = -1;
                }
                current += valley[index];
                visited.Add(index);
            }
            if (current > max)
            {
                max = current;
            }
        }

        Console.WriteLine(max);
    }
}

