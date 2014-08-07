using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        // Information
        int rounds = int.Parse(Console.ReadLine());
        BigInteger pointsP1 = 0;
        BigInteger pointsP2 = 0;
        int gamesP1 = 0;
        int gamesP2 = 0;
        bool xCardWinP1 = false;
        bool xCardWinP2 = false;

        // Get input and play the game
        for (int i = 0; i < rounds; i++)
        {
            int currentP1 = 0;
            int currentP2 = 0;
            bool xCardP1 = false;
            bool xCardP2 = false;

            // Cards Player 1
            for (int cards = 0; cards < 3; cards++)
            {
                string card = Console.ReadLine();
                switch (card)
                {
                    case "2": currentP1 += 10; break;
                    case "3": currentP1 += 9; break;
                    case "4": currentP1 += 8; break;
                    case "5": currentP1 += 7; break;
                    case "6": currentP1 += 6; break;
                    case "7": currentP1 += 5; break;
                    case "8": currentP1 += 4; break;
                    case "9": currentP1 += 3; break;
                    case "10": currentP1 += 2; break;
                    case "A": currentP1 += 1; break;
                    case "J": currentP1 += 11; break;
                    case "Q": currentP1 += 12; break;
                    case "K": currentP1 += 13; break;
                    case "Z": pointsP1 *= 2; break;
                    case "Y": pointsP1 -= 200; break;
                    case "X": xCardP1 = true; break;
                }
            }

            // Cards Player 2
            for (int cards = 0; cards < 3; cards++)
            {
                string card = Console.ReadLine();
                switch (card)
                {
                    case "2": currentP2 += 10; break;
                    case "3": currentP2 += 9; break;
                    case "4": currentP2 += 8; break;
                    case "5": currentP2 += 7; break;
                    case "6": currentP2 += 6; break;
                    case "7": currentP2 += 5; break;
                    case "8": currentP2 += 4; break;
                    case "9": currentP2 += 3; break;
                    case "10": currentP2 += 2; break;
                    case "A": currentP2 += 1; break;
                    case "J": currentP2 += 11; break;
                    case "Q": currentP2 += 12; break;
                    case "K": currentP2 += 13; break;
                    case "Z": pointsP2 *= 2; break;
                    case "Y": pointsP2 -= 200; break;
                    case "X": xCardP2 = true; break;
                }
            }

            // Check options
            if (currentP1 > currentP2 && !xCardP1 && !xCardP2)
            {
                pointsP1 += currentP1;
                gamesP1++;
            }
            else if (currentP1 < currentP2 && !xCardP1 && !xCardP2)
            {
                pointsP2 += currentP2;
                gamesP2++;
            }
            else if (xCardP1 && !xCardP2)
            {
                xCardWinP1 = true;
                break;
            }
            else if (!xCardP1 && xCardP2)
            {
                xCardWinP2 = true;
                break;
            }
            else if (xCardP1 && xCardP2)
            {
                pointsP1 += 50;
                pointsP2 += 50;
            }
        }

        // Output
        if (pointsP1 > pointsP2 && !xCardWinP1 && !xCardWinP2)
        {
            Console.WriteLine("First player wins!\nScore: {0}\nGames won: {1}", pointsP1, gamesP1);
        }
        else if (pointsP1 < pointsP2 && !xCardWinP1 && !xCardWinP2)
        {
            Console.WriteLine("Second player wins!\nScore: {0}\nGames won: {1}", pointsP2, gamesP2);
        }
        else if (pointsP1 == pointsP2 && !xCardWinP1 && !xCardWinP2)
        {
            Console.WriteLine("It's a tie!\nScore: {0}", pointsP1);
        }
        else if (xCardWinP1)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else if (xCardWinP2)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
    }
}