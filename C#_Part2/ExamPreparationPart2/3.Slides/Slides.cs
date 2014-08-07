using System;
using System.Text.RegularExpressions;

class Slides
{
    struct ball
    {
        public int W, H, D;

        public ball(int w, int h, int d)
        {
            this.W = w;
            this.H = h;
            this.D = d;
        }
    }
    private static ball Slide(string direction, ball ball)
    {
        switch (direction)
        {
            case "S L": ball.H += 1; ball.W -= 1; break;
            case "S R": ball.H += 1; ball.W += 1; break;
            case "S F": ball.H += 1; ball.D -= 1; break;
            case "S B": ball.H += 1; ball.D += 1; break;
            case "S FL": ball.H += 1; ball.D -= 1; ball.W -= 1; break;
            case "S FR": ball.H += 1; ball.D -= 1; ball.W += 1; break;
            case "S BL": ball.H += 1; ball.D += 1; ball.W -= 1; break;
            case "S BR": ball.H += 1; ball.D += 1; ball.W += 1; break;
        }
        return ball;
    }
    private static ball Teleport(string direction, ball ball)
    {
        string[] position = direction.Substring(1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        ball.W = int.Parse(position[0]);
        ball.D = int.Parse(position[1]);
        return ball;
    }
    static void Main()
    {
        // Create Cube
        string[] measures = Console.ReadLine().Split();
        int w = int.Parse(measures[0]);
        int h = int.Parse(measures[1]);
        int d = int.Parse(measures[2]);
        string[, ,] cube = new string[w, h, d];

        // Fill it with the input
        for (int level = 0; level < h; level++)
        {
            string[] rows = Console.ReadLine().Split('|');

            for (int row = 0; row < d; row++)
            {
                int col = 0;
                var matches = Regex.Matches(rows[row], @"\(.*?\)");
                foreach (Match m in matches)
                {
                    cube[col, level, row] = m.Value.Substring(1,m.Value.Length - 2);
                    col++;
                }
            }
        }

        // Set up ball
        string[] ballPos = Console.ReadLine().Split();
        ball ball = new ball(int.Parse(ballPos[0]), 0, int.Parse(ballPos[1]));

        string result = string.Empty;
        ball current;

        // Move the ball
        while (true)
        {
            string direction = cube[ball.W, ball.H, ball.D];
            current = ball;

            if (direction[0] == 'S')
            {
                ball = Slide(direction, ball);
                if (ball.H == h)
                {
                    result = "Yes";
                    break;
                }
            }
            else if (direction[0] == 'T')
            {
                ball = Teleport(direction, ball);
            }
            else if (direction == "E")
            {
                ball.H += 1;
                if (ball.H == h)
                {
                    result = "Yes";
                    break;
                }
            }

            if (ball.D >= d || ball.D < 0 ||
                ball.W >= w || ball.W < 0 ||
                direction == "B")
            {
                result = "No";
                break;
            }
        }

        Console.WriteLine(result);
        Console.WriteLine("{0} {1} {2}", current.W, current.H, current.D);
    }
}
