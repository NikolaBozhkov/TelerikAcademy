using System;
using System.Collections.Generic;
using System.Text;

class KaspichanNumbers
{
    static void Main()
    {
        ulong num = ulong.Parse(Console.ReadLine());

        string[] digits = new string[256];
        List<string> result = new List<string>();

        for (int i = 0, up = 65; i < 26; i++, up++)
        {
            digits[i] = ((char)up).ToString();
        }

        for (int i = 26, up = 65, low = 97; i < 256; i++, up++)
        {
            digits[i] = ((char)low).ToString() + ((char)up).ToString();

            if (up == 90)
            {
                up = 64;
                low++;
            }
        }

        while (num > 255)
        {
            ulong reminder = num % 256;
            num = num / 256;
            result.Add(digits[reminder]);
        }

        result.Add(digits[num]);
        result.Reverse();

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(result[i]);
        }
    }
}
