using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class MultiSnake
{
    struct Position
    {
        public int X, Y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    static void Main(string[] args)
    {
        // All snake elements
        Queue<Position> snakeBody = new Queue<Position>();

        // Snake Food Generator
        Random foodGenerator = new Random();

        // Set Snake speed
        double sleepTime = 100;

        // Snake directions
        Position[] moveDirections = new Position[]
        {
            new Position(1, 0), // Right
            new Position(0, 1), // Down
            new Position(-1, 0), // Left
            new Position(0, -1), // Up
        };

        // Current direction
        int currentDirection = 0; // 0 = right, 1 = down, 2 = left, 3 = up

        // Console settings
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight;

        // First snake and screen initialisation
        Position food = new Position(
            foodGenerator.Next(1, Console.WindowWidth - 1),
            foodGenerator.Next(1, Console.WindowHeight - 1));
        for (int i = 0; i <= 6; i++)
        {
            snakeBody.Enqueue(new Position(i, 0));
        }
        foreach (var item in snakeBody)
        {
            Console.SetCursorPosition(item.X, item.Y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("*");
        }
        Position snakeHead = snakeBody.Last();
        Console.SetCursorPosition(snakeHead.X, snakeHead.Y);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("@");

        while (true)
        {
            // Read user key
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.RightArrow)
                    if (currentDirection != 2) currentDirection = 0;
                if (pressedKey.Key == ConsoleKey.DownArrow)
                    if (currentDirection != 3) currentDirection = 1;
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                    if (currentDirection != 0) currentDirection = 2;
                if (pressedKey.Key == ConsoleKey.UpArrow)
                    if (currentDirection != 1) currentDirection = 3;
            }

            // Initialise food
            Console.SetCursorPosition(food.X, food.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+");

            // Previous snake head
            Position prevSnakeHead = snakeBody.Last();

            // New snake head
            Position newSnakeHead = new Position(
                prevSnakeHead.X + moveDirections[currentDirection].X,
                prevSnakeHead.Y + moveDirections[currentDirection].Y);

            // Check constraints
            if (newSnakeHead.X >= Console.WindowWidth ||
                newSnakeHead.X < 0 ||
                newSnakeHead.Y >= Console.WindowHeight ||
                newSnakeHead.Y < 0 ||
                snakeBody.Contains(newSnakeHead))
            {
                // Game is over
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Game over!!! Your points: {0}", snakeBody.Count);
                return;
            }
            
            // Write new snake head
            Console.SetCursorPosition(prevSnakeHead.X, prevSnakeHead.Y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("*");

            // Add new snake element and draw it on the console
            snakeBody.Enqueue(newSnakeHead);
            Console.SetCursorPosition(newSnakeHead.X, newSnakeHead.Y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("@");

            // Check if the snake is on food
            if (newSnakeHead.X == food.X && newSnakeHead.Y == food.Y)
            {
                // Feed the snake (the snake is eating)
                food = new Position(
                    foodGenerator.Next(1, Console.WindowWidth - 1),
                    foodGenerator.Next(1, Console.WindowHeight - 1));
                Console.SetCursorPosition(food.X, food.Y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("+");
            }
            else
            {
                // Remove last snake element (the snake is moving)
                Position p = snakeBody.Dequeue();
                Console.SetCursorPosition(p.X, p.Y);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" ");
            }

            // Slow the motion
            Thread.Sleep((int)sleepTime);

            // Change the speed
            sleepTime -= 0.05;
        }
    }
}