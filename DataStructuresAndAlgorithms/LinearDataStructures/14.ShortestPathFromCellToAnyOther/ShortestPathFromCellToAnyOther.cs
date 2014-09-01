namespace ShortestPathFromCellToAnyOther
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShortestPathFromCellToAnyOther
    {
        public static void Main()
        {
            var labyrinth = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "X", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            var resultLabyrinth = FillLabyrinthWithShortestPaths(labyrinth);

            for (int row = 0; row < resultLabyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < resultLabyrinth.GetLength(1); col++)
                {
                    Console.Write("{0} ", resultLabyrinth[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static string[,] FillLabyrinthWithShortestPaths(string[,] labyrinth)
        {
            var startPoint = FindStartPoint(labyrinth);

            var visited = new HashSet<Point>();
            var currentQueue = new Queue<Point>();
            currentQueue.Enqueue(startPoint);
            visited.Add(startPoint);

            int level = 0;

            while (currentQueue.Count > 0)
            {
                level++;
                var nextQueue = new Queue<Point>();

                while (currentQueue.Count > 0)
                {
                    var current = currentQueue.Dequeue();
                    var upPoint = new Point(current.Row - 1, current.Col);
                    var rightPoint = new Point(current.Row, current.Col + 1);
                    var downPoint = new Point(current.Row + 1, current.Col);
                    var leftPoint = new Point(current.Row, current.Col - 1);

                    var pointsToCheck = new Point[] { upPoint, rightPoint, downPoint, leftPoint };

                    foreach (var point in pointsToCheck)
                    {
                        if (IsValidPoint(labyrinth, point) && !visited.Contains(point))
                        {
                            nextQueue.Enqueue(point);
                            visited.Add(point);
                            labyrinth[point.Row, point.Col] = level.ToString();
                        }
                    }
                }

                currentQueue = nextQueue;
            }

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }

            return labyrinth;
        }

        public static Point FindStartPoint(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        return new Point(row, col);
                    }
                }
            }

            throw new ArgumentException("The labyrinth has no starting point.");
        }

        public static bool IsValidPoint(string[,] labyrinth, Point point)
        {
            if (point.Row >= 0 && point.Row < labyrinth.GetLength(0) &&
                point.Col >= 0 && point.Col < labyrinth.GetLength(1) &&
                labyrinth[point.Row, point.Col] == "0")
            {
                return true;
            }

            return false;
        }
    }
}
