// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal.
// Write a program that finds the longest sequence of equal strings in the matrix.

using System;
using System.Collections.Generic;

public class FindLongestSeqOfStrings
{
    public static void Main()
    {
        List<string> result = new List<string>();
        List<string> current = new List<string>();
        Console.Write("Enter the size of the matrix(N(row) x M(col)), N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the size of the matrix(N(row) x M(col)), M: ");
        int m = int.Parse(Console.ReadLine());
        string[,] matrix = new string[n, m];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("Enter element [{0}, {1}]: ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }

        // string[,] matrix = { Test matrix
        //                    {"ha", "xxx", "xo", "fi"},
        //                    {"fo", "xxx", "xxx", "xo"},
        //                    {"xxx", "xo", "xxx", "xo"},                         
        //                   };
        for (int row = 0; row < n; row++)
        {          
            for (int col = 0; col < m; col++)
            {
                string currentStr = matrix[row, col];

                // Check if the sequence is on the same row
                if (col < m - 1 && matrix[row, col + 1] == currentStr)
                {           
                    current.Add(currentStr);
                    current.Add(currentStr);

                    // Traverse
                    for (int travCol = col + 2; travCol < m && matrix[row, travCol] == currentStr; travCol++)
                    {
                        current.Add(currentStr);
                    }

                    if (current.Count > result.Count)
                    {
                        result.Clear();
                        result.AddRange(current);                        
                    }

                    current.Clear();
                }

                // Check if the sequence is on the diagonal
                if (row < n - 1 && col < m - 1 && matrix[row + 1, col + 1] == currentStr)
                {
                    current.Add(currentStr);
                    current.Add(currentStr);

                    // Traverse
                    for (int travCol = col + 2, travRow = row + 2; travCol < m && travRow < n &&
                        matrix[travRow, travCol] == currentStr; travCol++, travRow++)
                    {
                        current.Add(currentStr);
                    }

                    if (current.Count > result.Count)
                    {
                        result.Clear();
                        result.AddRange(current);                      
                    }

                    current.Clear();
                }

                // Check if the sequence is on the same col
                if (row < n - 1 && matrix[row + 1, col] == currentStr)
                {
                    current.Add(currentStr);
                    current.Add(currentStr);

                    // Traverse
                    for (int travRow = row + 2; travRow < n && matrix[travRow, col] == currentStr; travRow++)
                    {
                        current.Add(currentStr);
                    }

                    if (current.Count > result.Count)
                    {
                        result.Clear();
                        result.AddRange(current);                       
                    }

                    current.Clear();
                }           
            }           
        }

        Console.WriteLine("The longest sequence is:\n{0}", string.Join(", ", result));
    }
}