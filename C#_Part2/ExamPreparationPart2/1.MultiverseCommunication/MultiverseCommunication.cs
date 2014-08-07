using System;

class MultiverseCommunication
{
    static void Main()
    {
        string[] digits = new string[] { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
        string number = Console.ReadLine();
        decimal decimalNum = 0;
        for (decimal i = number.Length - 3, pow = 1; i >= 0; i -= 3, pow *= 13)
        {
            string digit = number.Substring((int)i, 3);
            decimalNum += Array.IndexOf(digits, digit) * pow;
        }

        Console.WriteLine(decimalNum);
    }
}