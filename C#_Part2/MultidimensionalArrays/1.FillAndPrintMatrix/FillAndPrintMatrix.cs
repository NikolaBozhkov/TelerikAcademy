// Write a program that fills and prints a matrix of size (n, n)(different patterns)

using System;

public class FillAndPrintMatrix
{
    public static void Main()
    {
        Console.WriteLine("This is subpoint A");
        SubPointA();
        Console.WriteLine("This is subpoint B");
        SubPointB();
        Console.WriteLine("This is subpoint C");
        SubPointC();
        Console.WriteLine("This is subpoint D");
        SubPointD();
    }
  
    private static void SubPointA()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int countRow = 1;
        int countCol = countRow + n;

        // Fill
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (col == 0)
                {
                    matrix[row, col] = countRow;
                }
                else
                {
                    matrix[row, col] = countCol;
                    countCol += n;
                }
            }

            countRow++;
            countCol = countRow + n;
        }

        // Print
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, 4}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static void SubPointB()
    {
        int count = 1;
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        // Fill
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
        }

        // Print
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, 4}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static void SubPointC()
    {
        int count = 1;
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int row = n - 1;
        int col = 0;
        bool halved = false;

        // Fill
        while (count <= n * n)
        {
            if (row == -1)
            {
                halved = true;
                row = 0;
            }

            // Check if still in first half
            if (halved == false)
            {
                matrix[row, col] = count;
                if (row == n - 1)
                {
                    row -= col + 1;
                    col = 0;
                }
                else
                {
                    row++;
                    col++;
                }
            }

            // Check if went to second half
            if (halved)
            {
                if (col == n - 1 && row > 0)
                {
                    row--;
                    col = col - row;
                    row = 0;
                }

                col++;
                matrix[row, col] = count;
                row++;
            }

            count++;
        }

        // Print
        for (int rowPrint = 0; rowPrint < n; rowPrint++)
        {
            for (int colPrint = 0; colPrint < n; colPrint++)
            {
                Console.Write("{0, 4}", matrix[rowPrint, colPrint]);
            }

            Console.WriteLine();
        }
    }

    private static void SubPointD()
    {
        int count = 1;
        int row = 0;
        int col = 0;
        int turn = 1;
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        // Run in spiral
        while (true)
        {
            // Final fill, fastest solution i came up with for infinite loop problem(better may exist)
            if (count == n * n)
            {
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = count;
                }
                else
                {
                    matrix[row, col] = count;
                }

                break;
            }

            // Check when to turn and fill
            switch (turn)
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

        // Print
        for (int rowPrint = 0; rowPrint < n; rowPrint++)
        {
            for (int colPrint = 0; colPrint < n; colPrint++)
            {
                Console.Write("{0, 4}", matrix[rowPrint, colPrint]);
            }

            Console.WriteLine();
        }
    }
}