using System;

class Bittris
{
    static void Main()
    {
        // NOT COMPLETED
        // Get the number of commands
        int numCom = int.Parse(Console.ReadLine());

        // Represent game field(top - bottom)
        int row1 = 0;
        int row2 = 0;
        int row3 = 0;
        int row4 = 0;
        int score = 0;
        int currentRow = 1;

        // Run game
        for (int i = 0; i < numCom; i++)
        {
            if (i % 4 == 0)
            {
                row1 = int.Parse(Console.ReadLine());
                currentRow = 1;
                i++;
            }

            char command = char.Parse(Console.ReadLine());
            switch (command)
            {
                case 'R':
                    {
                        switch (currentRow)
                        {
                            case 1: if ((row1 & 1) != 1) { row1 >>= 1; } break;
                            case 2: if ((row2 & 1) != 1) { row2 >>= 1; } break;
                            case 3: if ((row3 & 1) != 1) { row3 >>= 1; } break;
                        }
                    }
                    break;
                case 'L':
                    {
                        switch (currentRow)
                        {
                            case 1: if ((row1 & (1 << 7)) != 1) { row1 <<= 1; } break;
                            case 2: if ((row2 & (1 << 7)) != 1) { row2 <<= 1; } break;
                            case 3: if ((row3 & (1 << 7)) != 1) { row3 <<= 1; } break;
                        }
                    }
                    break;
            }

            switch (currentRow)
            {
                case 1:
                    {
                        if ((row1 & row2) == 0)
                        {
                            row2 |= row1;
                        }
                        else
                        {
                            for (int bit = 0, mask = 1; bit < 8; bit++, mask <<= 1)
                            {
                                if ((row1 & mask) >> bit == 1)
                                {
                                    score++;
                                }
                            }
                        }
                        currentRow++;
                    }
                    break;
                case 2:
                    {
                        if ((row2 & row3) == 0)
                        {
                            row3 |= row2;
                        }
                        else
                        {
                            for (int bit = 0, mask = 1; bit < 8; bit++, mask <<= 1)
                            {
                                if ((row2 & mask) >> bit == 1)
                                {
                                    score++;
                                }
                            }
                        }
                        currentRow++;
                    }
                    break;
                case 3:
                    {
                        if ((row3 & row4) == 0)
                        {
                            row4 |= row3;
                        }
                        else
                        {
                            for (int bit = 0, mask = 1; bit < 8; bit++, mask <<= 1)
                            {
                                if ((row3 & mask) >> bit == 1)
                                {
                                    score++;
                                }
                            }
                        }
                        currentRow++;
                    }
                    break;
            }
        }
    }
}