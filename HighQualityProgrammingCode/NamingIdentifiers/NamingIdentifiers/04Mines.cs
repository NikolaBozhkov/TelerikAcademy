namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mines
    {
        public static void Main(string[] arguments)
        {
            const int Max = 35;
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool blast = false;
            List<Score> champions = new List<Score>(6);
            int roll = 0;
            int col = 0;

            // Idk what these are...
            bool flag = true;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Lets play \"Mines\". Try your luck at finding the spots without mines." +
                    " Command 'top' shows the leaderboard, 'restart' starts a new game, 'exit' exits and goodbye!");
                    Dump(field);
                    flag = false;
                }

                Console.Write("Enter roll and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out roll) &&
                    int.TryParse(command[2].ToString(), out col) &&
                    roll <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        LeaderBoard(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = PlaceBombs();
                        Dump(field);
                        blast = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[roll, col] != '*')
                        {
                            if (bombs[roll, col] == '-')
                            {
                                YourTurn(field, bombs, roll, col);
                                counter++;
                            }

                            if (Max == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                Dump(field);
                            }
                        }
                        else
                        {
                            blast = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (blast)
                {
                    Dump(bombs);
                    Console.Write("\nHrrrrrr! You died heroically with {0} points. " + "Type your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Score t = new Score(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].ScoreCount < t.ScoreCount)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score a, Score b) => b.Name.CompareTo(a.Name));
                    champions.Sort((Score a, Score b) => b.ScoreCount.CompareTo(a.ScoreCount));
                    LeaderBoard(champions);

                    field = CreateGameField();
                    bombs = PlaceBombs();
                    counter = 0;
                    blast = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBravoooo! You opened 35 cells without a drop of blood.");
                    Dump(bombs);
                    Console.WriteLine("Type your name, Mr Batka: ");
                    string name = Console.ReadLine();
                    Score score = new Score(name, counter);
                    champions.Add(score);
                    LeaderBoard(champions);
                    field = CreateGameField();
                    bombs = PlaceBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            } 
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("FTW.");
            Console.Read();
        }

        private static void LeaderBoard(List<Score> scoreList)
        {
            Console.WriteLine("\nScore:");
            if (scoreList.Count > 0)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, scoreList[i].Name, scoreList[i].ScoreCount);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty leaderboard!\n");
            }
        }

        private static void YourTurn(char[,] field, char[,] bombs, int roll, int col)
        {
            char bombsCount = GetBombsCount(bombs, roll, col);
            bombs[roll, col] = bombsCount;
            field[roll, col] = bombsCount;
        }

        private static void Dump(char[,] board)
        {
            int rolls = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rolls; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rolls = 5;
            int cols = 10;
            char[,] gameField = new char[rolls, cols];

            for (int i = 0; i < rolls; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            // Idk what this is or the foreach below...
            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int col = i2 / cols;
                int roll = i2 % cols;
                if (roll == 0 && i2 != 0)
                {
                    col--;
                    roll = cols;
                }
                else
                {
                    roll++;
                }

                gameField[col, roll - 1] = '*';
            }

            return gameField;
        }

        private static void Calculations(char[,] field)
        {
            int col = field.GetLength(0);
            int roll = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < roll; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombsCount = GetBombsCount(field, i, j);
                        field[i, j] = bombsCount;
                    }
                }
            }
        }

        private static char GetBombsCount(char[,] field, int roll, int col)
        {
            int count = 0;
            int rolls = field.GetLength(0);
            int cols = field.GetLength(1);

            if (roll - 1 >= 0)
            {
                if (field[roll - 1, col] == '*')
                {
                    count++;
                }
            }

            if (roll + 1 < rolls)
            {
                if (field[roll + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[roll, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[roll, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((roll - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[roll - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((roll - 1 >= 0) && (col + 1 < cols))
            {
                if (field[roll - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((roll + 1 < rolls) && (col - 1 >= 0))
            {
                if (field[roll + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((roll + 1 < rolls) && (col + 1 < cols))
            {
                if (field[roll + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }

        public class Score
        {
            private string name;
            private int scoreCount;

            public Score() 
            { 
            }

            public Score(string name, int scoreCount)
            {
                this.Name = name;
                this.scoreCount = scoreCount;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int ScoreCount
            {
                get { return this.scoreCount; }
                set { this.scoreCount = value; }
            }
        }
    }
}
