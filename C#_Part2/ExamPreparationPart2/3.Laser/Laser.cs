using System;
using System.Collections.Generic;

class Laser
{   
    struct LaserPos
    {
        public int W, H, D;
        public LaserPos(int w, int h, int d)
        {
            this.W = w;
            this.H = h;
            this.D = d;
        }
    }
    private static bool CheckIfEdge(LaserPos laser, int width, int height, int depth)
    {
        bool edge = false;

        if ((laser.W == 0 && laser.D == 0) ||
            (laser.D == 0 && laser.H == 0) ||
            (laser.W == 0 && laser.H == 0) ||
            (laser.W == 0 && laser.H == height - 1) ||
            (laser.W == 0 && laser.D == depth - 1) ||
            (laser.D == 0 && laser.W == width - 1) ||
            (laser.D == 0 && laser.H == height - 1) ||
            (laser.H == 0 && laser.W == width - 1) ||
            (laser.H == 0 && laser.D == depth - 1) ||
            (laser.W == width - 1 && laser.D == depth - 1) ||
            (laser.H == height - 1 && laser.D == depth - 1) ||
            (laser.H == height - 1 && laser.W == width - 1))
        {
            edge = true;
        }

        return edge;
    }
    static void Main()
    {
        // Input data
        string dimensions = Console.ReadLine();
        string[] strVar = dimensions.Split();
        int width = int.Parse(strVar[0]);
        int height = int.Parse(strVar[1]);
        int depth = int.Parse(strVar[2]);

        string start = Console.ReadLine();
        strVar = start.Split();
        int startW = int.Parse(strVar[0]) - 1;
        int startH = int.Parse(strVar[1]) - 1;
        int startD = int.Parse(strVar[2]) - 1;

        string direction = Console.ReadLine();
        strVar = direction.Split();
        int dirW = int.Parse(strVar[0]);
        int dirH = int.Parse(strVar[1]);
        int dirD = int.Parse(strVar[2]);

        LaserPos laser = new LaserPos(startW, startH, startD);
        LaserPos last = laser;
        bool[, ,] cube = new bool[width, height, depth];

        while (true)
        {            
            if (CheckIfEdge(laser, width, height, depth) ||
                cube[laser.W, laser.H, laser.D] == true)
            {
                break;
            }
            cube[laser.W, laser.H, laser.D] = true;

            last = laser;

            if (laser.W == 0 || laser.W == width - 1)
            {
                dirW *= -1;
            }
            if (laser.H == 0 || laser.H == height - 1)
            {
                dirH *= -1;
            }
            if (laser.D == 0 || laser.D == depth - 1)
            {
                dirD *= -1;
            }

            laser.W += dirW;
            laser.H += dirH;
            laser.D += dirD;


        }

        Console.WriteLine("{0} {1} {2}", last.W + 1, last.H + 1, last.D + 1);
    }
}
