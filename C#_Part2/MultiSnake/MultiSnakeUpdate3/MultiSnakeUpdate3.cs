using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class MultiSnakeUpdate3
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

    public static void ConfigureConsole()
    {
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight;
    }

    static Queue<Position> GenerateSnake()
    {
        Queue<Position> snakeBody = new Queue<Position>();
        return snakeBody;
    }

    static Random FoodGenerator()
    {
        Random foodGenerator = new Random();
        return foodGenerator;
    }

    static double SetSpeed(double speed)
    {
        double sleepTime = speed;
        return sleepTime;
    }

    static Position[] SnakeDirections()
    {
        Position[] snakeDirections = new Position[]
        {
            new Position(1, 0), // Right
            new Position(0, 1), // Down
            new Position(-1, 0), // Left
            new Position(0, -1), // Up
        };
        return snakeDirections;
    }

    static Position Food(Random foodGenerator)
    {
        Position food = new Position(
        foodGenerator.Next(1, Console.WindowWidth - 1),
        foodGenerator.Next(1, Console.WindowHeight - 1));
        return food;
    }

    static void InitialiseSnake(Random foodGenerator, Queue<Position> snakeBody, int snakeNumber, ConsoleColor color)
    {
        for (int i = 0; i <= 6; i++)
        {
            snakeBody.Enqueue(new Position(i, snakeNumber));
        }
        foreach (var item in snakeBody)
        {
            Console.SetCursorPosition(item.X, item.Y);
            Console.ForegroundColor = color;
            Console.Write("*");
        }
        Position snakeHead = snakeBody.Last();
        Console.SetCursorPosition(snakeHead.X, snakeHead.Y);
        Console.ForegroundColor = color;
        Console.Write("@");
    }

    private static void WriteNewHead(Position prevHead, ConsoleColor color)
    {
        Console.SetCursorPosition(prevHead.X, prevHead.Y);
        Console.ForegroundColor = color;
        Console.Write("*");
    }

    private static Position AddNewSnakeElem(Queue<Position> snake, Position newHead, ConsoleColor color)
    {
        snake.Enqueue(newHead);
        Console.SetCursorPosition(newHead.X, newHead.Y);
        Console.ForegroundColor = color;
        Console.Write("@");
        return newHead;
    }

    private static void CheckIfOnFood(Queue<Position> snake, Random foodGenerator, ref Position food, ref Position newHead)
    {
        if (newHead.X == food.X && newHead.Y == food.Y)
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
            Position p = snake.Dequeue();
            Console.SetCursorPosition(p.X, p.Y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ");
        }
    }

    private static Position NewSnakeHead(Position[] snakeDirections, int currentDirection, ref Position prevFirstHead)
    {
        Position newFirstHead = new Position(
            prevFirstHead.X + snakeDirections[currentDirection].X,
            prevFirstHead.Y + snakeDirections[currentDirection].Y);
        return newFirstHead;
    }

    static void Main(string[] args)
    {
        //Console Configuration
        ConfigureConsole();

        //Generate Snake
        Queue<Position> firstSnake = GenerateSnake();
        Queue<Position> secondSnake = GenerateSnake();

        //Generate Food
        Random foodGenerator = FoodGenerator();

        //Set Snake's speed
        double snakeSpeed = SetSpeed(100);

        //Give Snake Directions
        Position[] snakeDirections = SnakeDirections();

        // Current direction
        int currentDirection = 0; // 0 = right, 1 = down, 2 = left, 3 = up
        int secondDirection = 0;

        Position food = Food(foodGenerator);

        int clicks = 0;
        int firstSnakeMinus = 0;
        int secondSnakeMinus = 0;
        int snake1Start = 5;
        int snake2Start = Console.WindowHeight - 5;

        //Initialise Snake
        InitialiseSnake(foodGenerator, firstSnake, snake1Start, ConsoleColor.Cyan);

        //Initialise Second Snake
        InitialiseSnake(foodGenerator, secondSnake, snake2Start, ConsoleColor.Red);

        int firstPoints = firstSnake.Count - firstSnakeMinus;
        int secondPoints = secondSnake.Count - secondSnakeMinus;

        while (true)
        {

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.RightArrow)
                    if (currentDirection != 2) currentDirection = 0;
                if (pressedKey.Key == ConsoleKey.DownArrow)
                    if (currentDirection != 3) currentDirection = 1;
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                    if (currentDirection != 0) currentDirection = 2;
                if (pressedKey.Key == ConsoleKey.UpArrow)
                    if (currentDirection != 1) currentDirection = 3;

                if (pressedKey.Key == ConsoleKey.D)
                    if (secondDirection != 2) secondDirection = 0;
                if (pressedKey.Key == ConsoleKey.S)
                    if (secondDirection != 3) secondDirection = 1;
                if (pressedKey.Key == ConsoleKey.A)
                    if (secondDirection != 0) secondDirection = 2;
                if (pressedKey.Key == ConsoleKey.W)
                    if (secondDirection != 1) secondDirection = 3;
            }


            // Initialise food
            Console.SetCursorPosition(food.X, food.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+");

            // Previous snake head
            Position prevFirstHead = firstSnake.Last();
            Position prevSecondHead = secondSnake.Last();

            // New snake head
            Position newFirstHead = NewSnakeHead(snakeDirections, currentDirection, ref prevFirstHead);
            Position newSecondHead = NewSnakeHead(snakeDirections, secondDirection, ref prevSecondHead);

            // Check constraints
            if (newFirstHead.X >= Console.WindowWidth ||
                newFirstHead.X < 0 ||
                newFirstHead.Y >= Console.WindowHeight ||
                newFirstHead.Y < 0 ||
                firstSnake.Contains(newFirstHead))
            {
                // Game is over
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Player 2 wins !!! with {0} points,\nPlayer 1 has {1} points", secondPoints, firstPoints);
                return;
            }

            if (newSecondHead.X >= Console.WindowWidth ||
                newSecondHead.X < 0 ||
                newSecondHead.Y >= Console.WindowHeight ||
                newSecondHead.Y < 0 ||
                secondSnake.Contains(newSecondHead))
            {
                // Game is over
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Player 1 wins !!! with {0} points,\nPlayer 2 has {1} points", firstPoints, secondPoints);
                return;
            }

            // Check Hits between the snakes
            if (firstSnake.Contains(newSecondHead))
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Second player: - 2 points");
                secondSnakeMinus += 2;
                clicks = 0;
            }

            if (secondSnake.Contains(newFirstHead))
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("First player: - 2 points");
                firstSnakeMinus += 2;
                clicks = 0;
            }
            // Give some time for the user to see the message
            // And not to stay forever
            if (clicks >= 40)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                          ");
                clicks = 0;
            }

            // Check if their heads collide            
            if (prevFirstHead.X == newSecondHead.X &&
                prevFirstHead.Y == newSecondHead.Y &&
                prevSecondHead.X == newFirstHead.X &&
                prevSecondHead.Y == newFirstHead.Y)
            {

                Console.SetCursorPosition(0, 0);

                if (firstPoints > secondPoints)
                {
                    Console.WriteLine("Player 1 wins with {0} points,\nPlayer 2 has {1} points !!!",
                        firstPoints, secondPoints);
                }
                else if (firstPoints < secondPoints)
                {
                    Console.WriteLine("Player 2 wins with {0} points,\nPlayer 1 has {1} points !!!",
                        secondPoints, firstPoints);
                }
                else
                {
                    Console.WriteLine("Equal !!! Both players have {0} points !!!", firstPoints);
                }
                return;
            }

            // Write new snake head            
            WriteNewHead(prevFirstHead, ConsoleColor.Cyan);
            WriteNewHead(prevSecondHead, ConsoleColor.Red);

            // Add new snake element and draw it on the console
            newFirstHead = AddNewSnakeElem(firstSnake, newFirstHead, ConsoleColor.Cyan);
            newSecondHead = AddNewSnakeElem(secondSnake, newSecondHead, ConsoleColor.Red);

            // Check if the snake is on food

            CheckIfOnFood(firstSnake, foodGenerator, ref food, ref newFirstHead);
            CheckIfOnFood(secondSnake, foodGenerator, ref food, ref newSecondHead);


            // Slow the motion
            Thread.Sleep((int)snakeSpeed);

            // Update          
            snakeSpeed -= 0.05;
            clicks++;
            firstPoints = firstSnake.Count - firstSnakeMinus;
            secondPoints = secondSnake.Count - secondSnakeMinus;
        }
    }
}
