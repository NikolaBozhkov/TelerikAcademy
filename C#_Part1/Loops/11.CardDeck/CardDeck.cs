// Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
// The cards should be printed with their English names. Use nested for loops and switch-case.

using System;

class CardDeck
{
    private enum Cards
    {
         Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King 
    }

    private enum Types
    {
        Clubs, Diamonds, Hearts, Spades // Спатия, Каро, Купа, Пика
    }

    static void Main()
    {
        // Counter for the new lines
        int counter = 0;
        Console.WriteLine("A standart card deck:");
        // Print the cards
        foreach (string card in Enum.GetNames(typeof(Cards)))
        {
            foreach (string type in Enum.GetNames(typeof(Types)))
            {
                // This is just for good looks
                string output = string.Format("{0} of {1}", card, type);
                Console.Write("{0}{1}", output, new string(' ', 19 - output.Length));
                counter++;
                if (counter % 4 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}