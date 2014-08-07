using System;

class OneTaskIsNotEnough
{
    private static int FirstTask(int length)
    {
        bool[] lamps = new bool[length];
        int turnedOn = 0;
        int action = 1;
        int index = 0;
        int result = 0;

        while (turnedOn < lamps.Length)
        {
            index = action - 1;
            int jumpOver = action + 1;
            while (index < lamps.Length)
            {
                if (lamps[index] == false)
                {
                    lamps[index] = true;
                    result = index;
                    turnedOn++;
                }
                index += jumpOver;
            }
            action++;
        }
        return ++result;
    }
    private static string SecondTask(string commands)
    {
        char[] steps = commands.ToCharArray();
        int index = 0;
        int positionX = 0;
        int positionY = 0;
        string direction = "up";
        while (true)
        {
            switch (steps[index])
            {
                case 'S':
                    switch (direction)
                    {
                        case "up": positionY++; break;
                        case "down": positionY--; break;
                        case "left": positionX--; break;
                        case "right": positionX++; break;
                    }
                    break;
                case 'L':
                    switch (direction)
                    {
                        case "up": positionX--; direction = "left"; break;
                        case "down": positionX++; direction = "right"; break;
                        case "left": positionY--; direction = "down"; break;
                        case "right": positionY++; direction = "up"; break;
                    }
                    break;
                case 'R':
                    switch (direction)
                    {
                        case "up": positionX++; direction = "right"; break;
                        case "down": positionX--; direction = "left"; break;
                        case "left": positionY++; direction = "up"; break;
                        case "right": positionY--; direction = "down"; break;
                    }
                    break;
            }
            index++;
            if (index == steps.Length)
            {
                index = 0;
            }
            if (positionX > steps.Length || positionY > steps.Length)
            {
                return "unbounded";
            }
            if (positionX == 0 && positionY == 0 && index == 0)
            {
                return "bounded";
            }
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string firstComm = Console.ReadLine();
        string secondComm = Console.ReadLine();
        Console.WriteLine(FirstTask(n));
        Console.WriteLine(SecondTask(firstComm));
        Console.WriteLine(SecondTask(secondComm));
    }
}
