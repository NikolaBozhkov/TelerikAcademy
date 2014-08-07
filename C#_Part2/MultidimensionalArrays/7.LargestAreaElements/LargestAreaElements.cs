// * Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. 
// Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).

using System;
using System.Collections.Generic;

class LargestAreaElements
{
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

    // I am using Breadth-first search, check it in Wikipedea, if you know the algorithm, comments are not needed, the names are enough : )
    private static int BFS(Node root, int[,] matrix)
    {
        Queue<Node> nodes = new Queue<Node>();
        List<Node> visited = new List<Node>();
        Node up = new Node(-1, 0);
        Node down = new Node(1, 0);
        Node left = new Node(0, -1);
        Node right = new Node(0, 1);
        int rootNumber = matrix[root.Row, root.Col];
        int count = 1;
        nodes.Enqueue(root);
        visited.Add(root);

        while (nodes.Count != 0)
        {
            Node currentNode = nodes.Dequeue();
            if (IsCellValid(currentNode, matrix, visited, up, rootNumber))
            {
                Node newNode = new Node(currentNode.Row - 1, currentNode.Col);
                count++;
                nodes.Enqueue(newNode);
                visited.Add(newNode);
            }

            if (IsCellValid(currentNode, matrix, visited, down, rootNumber))
            {
                Node newNode = new Node(currentNode.Row + 1, currentNode.Col);
                count++;
                nodes.Enqueue(newNode);
                visited.Add(newNode);
            }

            if (IsCellValid(currentNode, matrix, visited, left, rootNumber))
            {
                Node newNode = new Node(currentNode.Row, currentNode.Col - 1);
                count++;
                nodes.Enqueue(newNode);
                visited.Add(newNode);
            }

            if (IsCellValid(currentNode, matrix, visited, right, rootNumber))
            {
                Node newNode = new Node(currentNode.Row, currentNode.Col + 1);
                count++;
                nodes.Enqueue(newNode);
                visited.Add(newNode);
            }
        }

        return count;
    }

    static void Main()
    {
        // Our information
        int bestCount = 0;
        int currentCount = 0;
        int number = 0;
        int[,] matrix = 
        {
            { 1, 3, 2, 0, 2, 4 },
            { 3, 3, 3, 0, 4, 4 },
            { 4, 3, 2, 2, 3, 3 },
            { 4, 3, 3, 3, 3, 1 },
            { 4, 3, 3, 0, 2, 2 }
        };

        // Go through every element and apply BFS
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentCount = BFS(new Node(row, col), matrix);
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