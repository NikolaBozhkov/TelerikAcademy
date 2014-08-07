using System;
using System.Collections.Generic;

class SpecialValue
{
    static void Main()
    {
        int rowsNum = int.Parse(Console.ReadLine());

        int[][] jagged = new int[rowsNum][];

        for (int row = 0; row < rowsNum; row++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries);

            jagged[row] = new int[line.Length];

            for (int col = 0; col < line.Length; col++)
            {                
                jagged[row][col] = int.Parse(line[col]);
            }
        }
        
        int max = int.MinValue;
        
        for (int start = 0; start < jagged[0].Length; start++)
        {
            int paths = 0;
            int current = 0;
            int row = 0;
            int col = start;
            List<string> visited = new List<string>();

            while (true)
            {
                paths++;

                int element = jagged[row][col];

                visited.Add(row.ToString() + col.ToString());
                
                if (element < 0)
                {
                    current = paths + (element * -1);
                    break;
                }

                row++;
                col = element;

                if (row == rowsNum)
                {
                    row = 0;
                }

                if (visited.Contains(row.ToString() + col.ToString()))
                {
                    current = int.MinValue;
                    break;
                }
            }

            if (current > max)
            {
                max = current;
            }
        }

        Console.WriteLine(max);
    }
}
