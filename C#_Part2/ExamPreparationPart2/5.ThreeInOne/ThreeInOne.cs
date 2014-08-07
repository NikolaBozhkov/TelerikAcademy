using System;

class ThreeInOne
{
    private static int BlackJack(int[] arr)
    {
        int winner = -1;
        int[] copy = new int[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        Array.Sort(arr);

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] <= 21)
            {
                if (i > 0)
                {
                    if (arr[i] != arr[i - 1])
                    {
                        winner = arr[i];
                        break;
                    }
                    else
                    {
                        i = -1;
                    }
                }
                else
                {
                    winner = arr[i];
                    break;
                }
            }
        }

        if (winner == -1)
        {
            return -1;
        }
        else
        {
            return Array.IndexOf(copy, winner);
        }
    }
    private static int Cakes(int friends, int[] sizes)
    {
        Array.Sort(sizes);
        int bites = 0;
        int turn = 0;
        int index = sizes.Length - 1;

        while (index >= 0)
        {
            if (turn % 2 == 0)
            {
                bites += sizes[index];
                index--;
            }
            else
            {
                index -= friends;
            }
            turn++;
        }

        return bites;
    }
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ',', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        input = Console.ReadLine().Split(new char[] { ',', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        int friends = int.Parse(Console.ReadLine());
       
        int[] sizes = new int[input.Length];

        for (int i = 0; i < sizes.Length; i++)
        {
            sizes[i] = int.Parse(input[i]);
        }

        Console.WriteLine(BlackJack(arr));

        Console.WriteLine(Cakes(friends, sizes));
        // 3

        string[] sCoins = Console.ReadLine().Split(' ');
        int[] myCoins = new int[3];
        int[] desiredCoins = new int[3];
        for (int i = 0; i < 3; i++)
            myCoins[i] = int.Parse(sCoins[i]);
        for (int i = 3; i < 6; i++)
            desiredCoins[i - 3] = int.Parse(sCoins[i]);
        int numOfTransactions = 0;

        while (myCoins[0] < desiredCoins[0] && (myCoins[1] > desiredCoins[1] || myCoins[2] > desiredCoins[2]))
        {
            myCoins[1] = myCoins[1] - 11;
            myCoins[0]++;
            numOfTransactions++;
            while (myCoins[1] < desiredCoins[1] && myCoins[2] > desiredCoins[2])
            {
                myCoins[2] = myCoins[2] - 11;
                myCoins[1]++;
                numOfTransactions++;
            }
        }

        if (myCoins[0] < desiredCoins[0])
        {
            Console.WriteLine("-1");
            return;
        }

        while (myCoins[1] < desiredCoins[1] && (myCoins[0] > desiredCoins[0] || myCoins[2] > desiredCoins[2]))
        {
            while (myCoins[0] > desiredCoins[0] && myCoins[1] < desiredCoins[1])
            {
                myCoins[0]--;
                myCoins[1] = myCoins[1] + 9;
                numOfTransactions++;
            }
            while (myCoins[2] > desiredCoins[2] && myCoins[1] < desiredCoins[1])
            {
                myCoins[2] = myCoins[2] - 11;
                myCoins[1]++;
                numOfTransactions++;
            }
        }

        if (myCoins[1] < desiredCoins[1])
        {
            Console.WriteLine("-1");
            return;
        }

        while (myCoins[2] < desiredCoins[2] && (myCoins[1] > desiredCoins[1] || myCoins[0] > desiredCoins[0]))
        {
            myCoins[1]--;
            myCoins[2] = myCoins[2] + 9;
            numOfTransactions++;
            while (myCoins[1] < desiredCoins[1] && myCoins[0] > desiredCoins[0])
            {
                myCoins[0]--;
                myCoins[1] = myCoins[1] + 9;
                numOfTransactions++;
            }
        }
        if (myCoins[2] < desiredCoins[2])
            Console.WriteLine("-1");
        else
            Console.WriteLine(numOfTransactions);
    }
}
