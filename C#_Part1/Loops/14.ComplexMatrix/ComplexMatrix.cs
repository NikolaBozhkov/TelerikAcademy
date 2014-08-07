using System;

class ComplexMatrix
{
    static void Main()
    {
        // It's 11:55 and this is a solution that i made long time ago, so yea it's in different direction xD, sorry
        int count = 1;
        int row = 0;
        int col = 0;
        int turn = 1;
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        while (true)// Run in spiral
        {

            if (count == n * n)// Final fill, fastest solution i came up with for infinite loop problem(better may exist)
            {

                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = count;
                }

                else
                {
                    matrix[row, col] = count;
                }
                break;// Fully filled

            }

            switch (turn)// Check when to turn and fill
            {
                case 1:
                    while (row < n - 1 && matrix[row + 1, col] == 0)
                    {
                        matrix[row, col] = count;
                        row++;
                        count++;
                    }
                    break;
                case 2:
                    while (col < n - 1 && matrix[row, col + 1] == 0)
                    {
                        matrix[row, col] = count;
                        col++;
                        count++;
                    }
                    break;
                case 3:
                    while (row > 0 && matrix[row - 1, col] == 0)
                    {
                        matrix[row, col] = count;
                        row--;
                        count++;
                    }
                    break;
                case 4:
                    while (col > 0 && matrix[row, col - 1] == 0)
                    {
                        matrix[row, col] = count;
                        col--;
                        count++;
                    }
                    turn = 0;
                    break;
            }
            turn++;

        }

        for (int rowPrint = 0; rowPrint < n; rowPrint++)// Print
        {

            for (int colPrint = 0; colPrint < n; colPrint++)
            {
                Console.Write("{0, 4}", matrix[rowPrint, colPrint]);
            }
            Console.WriteLine();

        }
    }
}