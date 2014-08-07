using System;

class NineGagNumbers
{
    static void Main()
    {
        string[] digits = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };

        string num = Console.ReadLine();
        decimal decNum = 0;
        decimal multi = 1;

        string digit = string.Empty;
        string decode = string.Empty;

        if (Array.IndexOf(digits, num) != -1)
        {
            decNum += Array.IndexOf(digits, num);
        }
        else
        {
            for (int i = 0; i < num.Length; i++)
            {
                digit += num[i];

                if (Array.IndexOf(digits, digit) != -1)
                {
                    decode += Array.IndexOf(digits, digit);
                    digit = string.Empty;
                }
            }

            for (int i = decode.Length - 1; i >= 0; i--)
            {
                decNum += int.Parse(decode[i].ToString()) * multi;
                multi *= 9;
            }
        }

        Console.WriteLine(decNum);
    }
}
