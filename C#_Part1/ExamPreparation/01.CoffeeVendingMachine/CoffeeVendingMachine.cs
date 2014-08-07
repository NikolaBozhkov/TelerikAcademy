using System;

class CoffeeVendingMachine
{
    static void Main()
    {
        // Take Input
        decimal[] coins = new decimal[5];
        for (int i = 0; i < 5; i++)
        {
            coins[i] = decimal.Parse(Console.ReadLine());
        }
        decimal available = coins[0] * 0.05m + coins[1] * 0.1m + coins[2] * 0.2m + coins[3] * 0.5m + coins[4];
        decimal amount = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());
        decimal change = amount - price;

        // Check if the put in coins are not enough
        if (amount < price)
        {
            Console.WriteLine("More {0}", price - amount);
        }

        // Check if the amount is enough
        if (amount >= price)
        {
            if (change <= available)
            {
                Console.WriteLine("Yes {0}", available - change);
            }
            else
            {
                Console.WriteLine("No {0}", -(available - change));
            }
        }
    }
}