using System;

class KukataIsDancing
{
    static void Main()
    {
        int numDances = int.Parse(Console.ReadLine());
        string[] moves = new string[numDances];

        for (int i = 0; i < numDances; i++)
        {
            moves[i] = Console.ReadLine();
        }

        int[,] danceGround = 
        {
            { 1, 2, 1 },
            { 2, 0, 2 },
            { 1, 2, 1 }
        };// 1 - red, 2 - blue, 0 - green

        for (int i = 0; i < moves.Length; i++)
        {
            int row = 1;
            int col = 1;
            string current = "up";
            string dance = moves[i];

            for (int j = 0; j < dance.Length; j++)
            {
                switch (dance[j])
                {
                    case 'L':
                        switch (current)
	                    {
                            case "up": current = "left"; break;
                            case "left": current = "down"; break;
                            case "down": current = "right"; break;
                            case "right": current = "up"; break;
	                    }
                        break;
                    case 'R':
                        switch (current)
                        {
                            case "up": current = "right"; break;
                            case "right": current = "down"; break;
                            case "down": current = "left"; break;
                            case "left": current = "up"; break;
                        }
                        break;
                    case 'W':
                        switch (current)
                        {
                            case "up": row++; break;
                            case "right": col++; break;
                            case "down": row--; break;
                            case "left": col--; break;
                        }
                        break;
                }

                if (row == -1) { row = 2; };
                if (row == 3) { row = 0; };
                if (col == -1) { col = 2; };
                if (col == 3) { col = 0; };
            }

            switch (danceGround[row, col])
            {
                case 0:
                    Console.WriteLine("GREEN");
                    break;
                case 1:
                    Console.WriteLine("RED");
                    break;
                case 2:
                    Console.WriteLine("BLUE");
                    break;
            }
        }
    }
}
