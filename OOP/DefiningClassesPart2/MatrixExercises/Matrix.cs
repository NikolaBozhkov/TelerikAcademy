using System;

// I am trying to get closest to numeric constraint, as there is no such directly
public class Matrix<T>
    where T : struct, 
              IComparable, 
              IComparable<T>, 
              IConvertible,
              IEquatable<T>,
              IFormattable
{
    // Fields
    private T[,] matrix;

    // Constructors
    public Matrix(int rows, int columns)
    {
        this.matrix = new T[rows, columns];
    }

    // Properties
    public T this[int row, int column]
    {
        get
        {
            if (row < this.matrix.GetLength(0) && column < this.matrix.GetLength(1))
            {
                return this.matrix[row, column];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }

        set
        {
            if (row < this.matrix.GetLength(0) && column < this.matrix.GetLength(1))
            {
                this.matrix[row, column] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }
    }

    // Methods
    public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        int rows = firstMatrix.matrix.GetLength(0);
        int cols = firstMatrix.matrix.GetLength(1);
        if (rows == secondMatrix.matrix.GetLength(0) && cols == secondMatrix.matrix.GetLength(1))
        {
            Matrix<T> newMatrix = new Matrix<T>(rows, cols);
            for (int row = 0; row < firstMatrix.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    checked
                    {
                        newMatrix[row, col] = (T)Convert.ChangeType(Convert.ToDecimal(firstMatrix[row, col])
                            + Convert.ToDecimal(secondMatrix[row, col]), typeof(T));
                    }
                }
            }

            return newMatrix;
        }
        else
        {
            throw new ArgumentException("The matrices are not of the same size.");
        }
    }

    public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        int rows = firstMatrix.matrix.GetLength(0);
        int cols = firstMatrix.matrix.GetLength(1);
        if (rows == secondMatrix.matrix.GetLength(0) && cols == secondMatrix.matrix.GetLength(1))
        {
            Matrix<T> newMatrix = new Matrix<T>(rows, cols);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    checked
                    {
                        newMatrix[row, col] = (T)Convert.ChangeType(Convert.ToDecimal(firstMatrix[row, col])
                            - Convert.ToDecimal(secondMatrix[row, col]), typeof(T));
                    }
                }
            }

            return newMatrix;
        }
        else
        {
            throw new ArgumentException("The matrices are not of the same size.");
        }
    }

    public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        int rows = firstMatrix.matrix.GetLength(0);
        int cols = firstMatrix.matrix.GetLength(1);
        if (cols == secondMatrix.matrix.GetLength(0))
        {
            Matrix<T> newMatrix = new Matrix<T>(rows, cols);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        checked
                        {
                            newMatrix[row, col] = (T)Convert.ChangeType(Convert.ToDecimal(firstMatrix[row, i])
                            * Convert.ToDecimal(secondMatrix[i, col]), typeof(T));
                        }
                    }
                }
            }

            return newMatrix;
        }
        else if (firstMatrix == null || secondMatrix == null)
        {
            throw new ArgumentNullException("Matrix cannot be null.");
        }
        else
        {
            throw new ArgumentException("The matrices have different number of rows and columns.");
        }
    }

    public static bool operator true(Matrix<T> matrix)
    {
        for (int row = 0; row < matrix.matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.matrix.GetLength(1); col++)
            {
                if (Convert.ToDecimal(matrix[row, col]) == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        for (int row = 0; row < matrix.matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.matrix.GetLength(1); col++)
            {
                if (Convert.ToDecimal(matrix[row, col]) != 0)
                {
                    return true;
                }
            }
        }

        return false;
    }
}