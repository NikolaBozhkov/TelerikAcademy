using System;

class DurankulakNumbers
{
    static void Main()
    {
        string strNum = Console.ReadLine();
        string[] digits = new string[168];

        for (int i = 0, up = 65; i < 26; i++, up++)
        {
            digits[i] = ((char)up).ToString();
        }

        for (int i = 26, up = 65, low = 97; i < 168; i++, up++)
        {
            digits[i] = ((char)low).ToString() + ((char)up).ToString();
            if (up == 90)
            {
                up = 64;
                low++;
            }
        }

        decimal num = 0;
        decimal pow = 1;
        while (strNum != string.Empty)
        {
            string digit = strNum.Substring(strNum.Length - 1, 1);
            strNum = strNum.Remove(strNum.Length - 1);
            if (strNum != string.Empty && char.IsLower(strNum[strNum.Length - 1]))
            {
                digit = digit.Insert(0, strNum[strNum.Length - 1].ToString());
                strNum = strNum.Remove(strNum.Length - 1);
            }
            num += Array.IndexOf(digits, digit) * pow;
            pow *= 168;
        }
        Console.WriteLine(num);
    }
}
