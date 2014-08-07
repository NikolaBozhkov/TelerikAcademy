// Write a program that reads a text file containing a square matrix of numbers 
// and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
// The first line in the input file contains the size of matrix N. 
// Each of the next N lines contain N numbers separated by space. 
// The output should be a single number in a separate text file. 

using System;
using System.IO;

public class WorkWithMatrixFromFile
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"matrix.txt");
        StreamWriter writer = new StreamWriter(@"result.txt");

        // The variables we need for the max sum
        int currentSum = 0;
        int maxSum = int.MinValue;

        using (reader)
        {
            string line = reader.ReadLine();
            int size = int.Parse(line);
            int[,] matrix = new int[size, size];

            // Filling the matrix
            for (int row = 0; row < size; row++)
            {
                line = reader.ReadLine();
                for (int col = 0, elem = 0; col < size; col++, elem += 2)
                {
                    matrix[row, col] = int.Parse(line[elem].ToString());
                }
            }

            // Finding the max sum
            for (int row = 0; row < size - 1; row++)
            {
                for (int col = 0; col < size - 1; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
        }

        // Writing the result
        using (writer)
        {
            writer.Write(maxSum.ToString());
        }
    }
}