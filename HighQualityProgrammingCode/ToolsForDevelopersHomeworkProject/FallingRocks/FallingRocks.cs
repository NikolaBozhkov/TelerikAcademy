using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class FallingRocks
{
    private static ConsoleKey key = ConsoleKey.Spacebar;
    private static bool playGame = true;

    // The project is old, this is why it's all in one file, but I guess it's ok for the purpose of the homework 
    public static void Main()
    {
        Console.Title = "Falling Rocks";

        while (playGame)
        {
            WelcomeScreen();

            // Dwarf Info
            int dwarfX = (Console.BufferWidth / 2) - 15;
            int oldDwarfX = dwarfX;

            // Rocks Info
            string[] types = new string[] { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";", "-" };
            List<Position> rocks = new List<Position>();

            Random randomGen = new Random();

            // Start Info  
            decimal points = 0;
            ConsoleConfiguration();
            InitialiseDwarf(dwarfX);

            // Start
            while (true)
            {
                // Check key
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow && dwarfX > 0)
                    {
                        oldDwarfX = dwarfX;
                        dwarfX -= 1;
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow && dwarfX < 52)
                    {
                        oldDwarfX = dwarfX;
                        dwarfX += 1;
                    }

                    if (pressedKey.Key == ConsoleKey.Spacebar)
                    {
                        PauseGame();
                    }

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                }

                // Update Points
                ShowPoints(points);

                // Update Rocks
                NewRocks(rocks, randomGen, types);
                MoveRocks(rocks);

                // Check Collision
                if (Collision(dwarfX, rocks))
                {
                    break;
                }

                points = PrintRocksAndGetPoints(rocks, points);
                MoveDwarf(dwarfX, oldDwarfX);

                Thread.Sleep(120);
            }

            EndGame();
        }
    }

    private static void WelcomeScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight;
        Console.SetCursorPosition((Console.BufferWidth / 2) - 14, (Console.BufferHeight / 2) - 5);
        Console.Write("Welcome to Falling Rocks");
        Console.SetCursorPosition((Console.BufferWidth / 2) - 14, (Console.BufferHeight / 2) - 4);
        Console.Write("Press any key to play !");
        Console.ReadKey(true);
        Console.SetCursorPosition((Console.BufferWidth / 2) - 14, (Console.BufferHeight / 2) - 5);
        Console.Write("                        ");
        Console.SetCursorPosition((Console.BufferWidth / 2) - 14, (Console.BufferHeight / 2) - 4);
        Console.Write("                       ");
    }

    /// <summary>
    /// Draws the separator for the points and the field
    /// </summary>
    private static void ConsoleConfiguration()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < 25; i++)
        {
            Console.SetCursorPosition(56, i);
            Console.Write("|");
        }
    }

    /// <summary>
    /// Puts the drawf at the bottom of the console window(centered) and draws it
    /// </summary>
    private static void InitialiseDwarf(int dwarfX)
    {
        Console.SetCursorPosition(dwarfX, 24);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("(0)");
    }

    /// <summary>
    /// Moves the dwarf to a new position
    /// </summary>
    private static void MoveDwarf(int dwarfX, int oldDwarfX)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(oldDwarfX, 24);
        Console.Write("   ");
        Console.SetCursorPosition(dwarfX, 24);
        Console.Write("(0)");
    }

    /// <summary>
    /// Creates a rock of random type at random 'x' location on the first row
    /// </summary>
    private static void NewRocks(List<Position> rocks, Random randomGen, string[] types)
    {
        int numRocks = randomGen.Next(2, 2);
        for (int i = 0; i < numRocks; i++)
        {
            Position newRock = new Position(randomGen.Next(0, 55), 0, types[randomGen.Next(0, 12)]);
            rocks.Add(newRock);
        }
    }

    /// <summary>
    /// Moves the rock on the next roll
    /// </summary>
    private static void MoveRocks(List<Position> rocks)
    {
        for (int i = rocks.Count - 1; i >= 0; i--)
        {
            Position rock = rocks[i];
            rock.Y += 1;
            rocks[i] = rock;
        }
    }

    private static decimal PrintRocksAndGetPoints(List<Position> rocks, decimal points)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = rocks.Count - 1; i >= 0; i--)
        {
            Console.SetCursorPosition(rocks[i].X, rocks[i].Y - 1);
            Console.Write(" ");

            if (rocks[i].Y > 24)
            {
                points++;
                rocks.RemoveAt(i);
            }

            Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
            Console.Write(rocks[i].Type);
        }

        return points;
    }

    private static bool Collision(int dwarfX, List<Position> rocks)
    {
        foreach (Position rock in rocks)
        {
            if ((rock.X == dwarfX || rock.X == dwarfX + 1 || rock.X == dwarfX + 2) && rock.Y == 24)
            {
                return true;
            }
        }

        return false;
    }

    private static void ShowPoints(decimal points)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(58, 0);
        Console.Write("Points: {0}", points);
    }

    private static void PauseGame()
    {
        Console.SetCursorPosition(58, 1);
        Console.Write("Game Paused");
        Console.ReadKey(true);
        key = ConsoleKey.Enter;
        Console.SetCursorPosition(58, 1);
        Console.Write("           ");
    }

    private static void EndGame()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(58, 5);
        Console.Write("Game Over");
        Console.SetCursorPosition(58, 6);
        Console.Write("Press \"Enter\" to play");
        Console.SetCursorPosition(58, 7);
        Console.Write("again or \"Esc\" to exit");

        while (key != ConsoleKey.Enter && key != ConsoleKey.Escape)
        {
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter) 
            { 
                playGame = true; 
            }

            if (key == ConsoleKey.Escape) 
            { 
                playGame = false; 
            }
        }

        key = 0;
    }

    private struct Position
    {
        public readonly string Type;
        public readonly int X;
        public int Y;

        public Position(int x, int y, string type)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
        }
    }
}
