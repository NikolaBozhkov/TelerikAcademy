using System;

class BullsAndCows
{
    static void Main()
    {
        // Take input
        string secretNum = Console.ReadLine();
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        const char used = '^';
        const char usedSecret = '*';
        bool noResult = true;

        for (int num = 1000; num <= 9999; num++)
        {
            int countBulls = 0;
            int countCows = 0;
            char[] digits = num.ToString().ToCharArray();
            char[] secretDigits = secretNum.ToCharArray();

            if (digits[1] >= '1' && digits[2] >= '1' && digits[3] >= '1')
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    if (digits[i] == secretDigits[i])
                    {
                        countBulls++;
                        secretDigits[i] = usedSecret;
                        digits[i] = used;
                    }
                }

                for (int i = 0; i < digits.Length; i++)
                {
                    for (int j = 0; j < digits.Length; j++)
                    {
                        if (secretDigits[i] == digits[j])
                        {
                            countCows++;
                            secretDigits[i] = usedSecret;
                            digits[j] = used;
                        }
                    }                    
                }

                if (countBulls == bulls && countCows == cows)
                {
                    noResult = false;
                    Console.Write(num + " ");
                }
            }
        }

        if (noResult)
        {
            Console.WriteLine("No");
        }
    }
}