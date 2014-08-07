// * Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

using System;
using System.Text;

public class MatrixOverload
{
    public static void Main()
    {
        Matrix matrix1 = new Matrix(4, 4);
        Matrix matrix2 = new Matrix(4, 4);

        // Filling them
        Random generator = new Random();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrix1[i, j] = generator.Next(10);
                matrix2[i, j] = generator.Next(10);
            }
        }
        
        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("Matrix 1 + Matrix 2:");
        Console.WriteLine(matrix1 + matrix2);
        Console.WriteLine("Matrix 1 - Matrix 2:");
        Console.WriteLine(matrix1 - matrix2);
        Console.WriteLine("Matrix 1 * Matrix 2:");
        Console.WriteLine(matrix1 * matrix2);
    }

    private class Matrix
    {
        private int[,] matrix;
        private int rows, cols;
        
        // Constructor
        public Matrix(int rows, int columns)
        {
            this.matrix = new int[rows, columns];
            this.rows = rows;
            this.cols = columns;
        }
        
        // Property for getting and setting elements
        public int this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        public int Length
        {
            get { return matrix.Length; }
        }

        public static Matrix operator +(Matrix firstM, Matrix secondM)
        {
            Matrix newMatrix = new Matrix(firstM.rows, firstM.cols);
            for (int row = 0; row < firstM.rows; row++)
            {
                for (int col = 0; col < firstM.cols; col++)
                {
                    newMatrix[row, col] = firstM[row, col] + secondM[row, col];
                }
            }

            return newMatrix;
        }

        public static Matrix operator -(Matrix firstM, Matrix secondM)
        {
            Matrix newMatrix = new Matrix(firstM.rows, firstM.cols);
            for (int row = 0; row < firstM.rows; row++)
            {
                for (int col = 0; col < firstM.cols; col++)
                {
                    newMatrix[row, col] = firstM[row, col] - secondM[row, col];
                }
            }

            return newMatrix;
        }

        // This is a bit confusing...
        public static Matrix operator *(Matrix firstM, Matrix secondM)
        {
            Matrix newMatrix = new Matrix(firstM.rows, secondM.cols);
            for (int row = 0; row < newMatrix.rows; row++)
            {
                for (int col = 0; col < newMatrix.cols; col++)
                {
                    for (int i = 0; i < firstM.cols; i++)
                    {
                        newMatrix[row, col] += firstM[row, i] * secondM[i, col];
                    }
                }
            }

            return newMatrix;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    result.Append((this.matrix[row, col] + " ").PadLeft(5));
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}