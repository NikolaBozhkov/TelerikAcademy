// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

public class FindMaxSumSquare
{
    public static void Main()
    {
        int bestSum = int.MinValue;
        int[,] bestSquare = new int[3, 3];
        Console.Write("Enter the size of the matrix(N(row) x M(col)), N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the size of the matrix(N(row) x M(col)), M: ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("Enter element [{0}, {1}]: ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        // int[,] matrix = { Test matrix
        //                    {4, 5, 1, 4, 5, 6, 2},
        //                    {3, 4, 3, 6, 1, 1, 3},
        //                    {9, 1, 9, 6, 8, 9, 1}, 
        //                    {3, 5, 7, 5, 3, 7, 9},
        //                    {4, 6, 2, 1, 6, 9, 6},
        //                };
        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < m - 2; col++)
            {
                // Sum
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;

                    // Filling the result, I thought about using StringBuilder(easier), but decided to go with matrix : )
                    for (int squareRow = 0; squareRow < 3; squareRow++)
                    {
                        for (int squareCol = 0; squareCol < 3; squareCol++)
                        {
                            bestSquare[squareRow, squareCol] = matrix[row + squareRow, col + squareCol];  
                        }
                    }                             
                }
            }
        }

        Console.WriteLine("Best sum: {0}", bestSum);
        Console.WriteLine("Best square:");
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write("{0} ", bestSquare[row, col]);                
            }

            Console.WriteLine();
        }
    }
}