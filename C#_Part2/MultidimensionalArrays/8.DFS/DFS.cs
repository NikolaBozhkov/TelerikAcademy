using System;
using System.Collections.Generic;

class DFS
{
    static int currentCount;

    public struct Node
    {
        public int Row, Col;

        public Node(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    private static bool IsCellValid(Node currentNode, int[,] matrix, List<Node> visited, Node direction, int rootNumber)
    {
        Node cellToCheck = new Node(currentNode.Row + direction.Row, currentNode.Col + direction.Col);

        // All the checks we need
        if (cellToCheck.Row < 0 || cellToCheck.Row >= matrix.GetLength(0) || cellToCheck.Col < 0
           || cellToCheck.Col >= matrix.GetLength(1) || visited.Contains(cellToCheck) || matrix[cellToCheck.Row, cellToCheck.Col] != rootNumber)
        {
            return false;
        }

        return true;
    }

    private static void DFSAlgorithm(Node currentNode, int[,] matrix, List<Node> visited)
    {
        Node up = new Node(-1, 0);
        Node down = new Node(1, 0);
        Node left = new Node(0, -1);
        Node right = new Node(0, 1);
        int rootNumber = matrix[currentNode.Row, currentNode.Col];
        visited.Add(currentNode);

        if (IsCellValid(currentNode, matrix, visited, up, rootNumber))
        {
            currentCount++;
            DFSAlgorithm(new Node(currentNode.Row - 1, currentNode.Col), matrix, visited);
        }

        if (IsCellValid(currentNode, matrix, visited, down, rootNumber))
        {
            currentCount++;
            DFSAlgorithm(new Node(currentNode.Row + 1, currentNode.Col), matrix, visited);
        }

        if (IsCellValid(currentNode, matrix, visited, left, rootNumber))
        {
            currentCount++;
            DFSAlgorithm(new Node(currentNode.Row, currentNode.Col - 1), matrix, visited);
        }

        if (IsCellValid(currentNode, matrix, visited, right, rootNumber))
        {
            currentCount++;
            DFSAlgorithm(new Node(currentNode.Row, currentNode.Col + 1), matrix, visited);
        }
    }

    static void Main()
    {
        // Our information
        int bestCount = 0;
        int number = 0;
        int[,] matrix = 
        {
            { 1, 3, 2, 3, 2, 4 },
            { 3, 3, 3, 2, 4, 4 },
            { 4, 3, 2, 2, 3, 3 },
            { 4, 3, 1, 3, 3, 1 },
            { 4, 3, 3, 3, 2, 2 }
        };

        // Go through every element and apply DFS
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentCount = 1;
                DFSAlgorithm(new Node(row, col), matrix, new List<Node>());
                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    number = matrix[row, col];
                }
            }
        }

        Console.WriteLine("\nThe largest area of equal neighbor elements is {0} and the number is {1}\n", bestCount, number);
    }
}