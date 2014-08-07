using System;

class Secrets
{
    static void Main()
    {
        // Take input
        string num = Console.ReadLine();
        int specSum = 0;
        string secretAlphaSec = string.Empty;

        // Run algorithm for special sum
        for (int i = num.Length - 1, pos = 1; i >= 0; i--, pos++)
        {
            if (pos % 2 == 0 && num[i] != '-')
            {
                specSum += (int)Math.Pow(int.Parse(num[i].ToString()), 2) * pos;
            }
            else if (pos % 2 != 0 && num[i] != '-')
            {
                specSum += (int)Math.Pow(pos, 2) * int.Parse(num[i].ToString());
            }
        }

        // Run algorithm for secret Alpha sequence
        int length = specSum % 10;
        if (length != 0)
        {
            int letter = (specSum % 26) + 65;
            for (int i = 0; i < length; i++, letter++)
            {
                if (letter > 90)
                {
                    letter = 65;
                }

                secretAlphaSec += (char)letter;
            }

            Console.WriteLine("{0}\n{1}", specSum, secretAlphaSec);
        }
        else
        {
            Console.WriteLine("{0}\n{1} has no secret alpha-sequence", specSum, num);
        }
    }
}