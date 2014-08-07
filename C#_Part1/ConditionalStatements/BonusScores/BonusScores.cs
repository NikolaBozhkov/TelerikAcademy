// Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit as an input.
// If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. 
// If it is zero or if the value is not a digit, the program must report an error.
// Use a switch statement and at the end print the calculated new value in the console.

using System;

public class BonusScores
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Please enter a digit[1;9]: ");
            string line = Console.ReadLine();
            int digit;
            int switcher;
            if (int.TryParse(line, out digit) && digit > 0 && digit < 10)
            {
                if (digit >= 1 && digit <= 3)
                {
                    switcher = 1;
                }
                else if (digit >= 4 && digit <= 6)
                {
                    switcher = 2;
                }
                else
                {
                    switcher = 3;
                }

                switch (switcher)
                {
                    case 1:
                        int value = digit * 10;
                        Console.WriteLine("The new value of {0} is: {1}", digit, value);
                        break;
                    case 2:
                        value = digit * 100;
                        Console.WriteLine("The new value of {0} is: {1}", digit, value);
                        break;
                    case 3:
                        value = digit * 1000;
                        Console.WriteLine("The new value of {0} is: {1}", digit, value);
                        break;
                }

                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}