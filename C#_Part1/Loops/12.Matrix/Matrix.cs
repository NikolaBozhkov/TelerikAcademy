// Write a program that reads from the console a positive integer number N (N < 20)
// and outputs a matrix like the following: *can't really paste the example*, but it works properly : ) 

using System;

class Matrix
{
    static void Main()
    {
        // Take input
        Console.Write("Enter the size of the matrix(size < 20): ");
        int size = int.Parse(Console.ReadLine());

        // Draw matrix
        for (int row = 1; row <= size; row++)
        {
            for (int col = row; col < size + row; col++)
            {
                // Again just for looks
                string output = string.Format("{0}", col);
                Console.Write("{0}{1}", output, new string(' ', 3 - output.Length));
            }
            Console.WriteLine();
        }
    }
}