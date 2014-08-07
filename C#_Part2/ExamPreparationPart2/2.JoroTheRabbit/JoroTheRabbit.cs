using System;
using System.Collections.Generic;

class JoroTheRabbit
{

    static void Main()
    {
        // Input data
        string nums = Console.ReadLine();
        string[] strTerrain = nums.Split(new char[] { ' ', ',' },
        StringSplitOptions.RemoveEmptyEntries);

        int[] terrain = new int[strTerrain.Length];

        for (int i = 0; i < strTerrain.Length; i++)
        {
            terrain[i] = int.Parse(strTerrain[i]);
        }

        // Cycle jumps
        int maxLength = 0;
        for (int startPos = 0; startPos < terrain.Length; startPos++)
        {
            for (int steps = 1; steps <= terrain.Length; steps++)
            {
                int currLength = 1;
                int index = startPos;
                int next = index + steps;

                if (next >= terrain.Length)
                {
                    next -= terrain.Length;
                }
                while (terrain[index] < terrain[next])
                {
                    currLength++;                    
                    index = next;
                    next += steps;

                    if (next >= terrain.Length)
                    {
                        next -= terrain.Length;
                    }
                }
                if (currLength > maxLength)
                {
                    maxLength = currLength;
                }
            }
        }

        Console.WriteLine(maxLength);
    }
}
