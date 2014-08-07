using System;

class DrunkenNumbers
{
    static void Main()
    {
        // Take Input And Process
        int rounds = int.Parse(Console.ReadLine());
        int vladko = 0;
        int mitko = 0;
        for (int i = 0; i < rounds; i++)
        {
            decimal numPre = Math.Abs(decimal.Parse(Console.ReadLine()));
            string num = numPre.ToString();
            for (int m = 0, v = num.Length - 1; m < num.Length / 2; m++, v--)
            {
                mitko += int.Parse(num[m].ToString());
                vladko += int.Parse(num[v].ToString());
            }
            if (num.Length % 2 != 0)
            {
                mitko += int.Parse(num[(num.Length / 2)].ToString());
                vladko += int.Parse(num[(num.Length / 2)].ToString());
            }           
        }

        // Output
        if (mitko > vladko)
        {
            Console.WriteLine("M {0}", mitko - vladko);
        }
        else if (mitko < vladko)
        {
            Console.WriteLine("V {0}", vladko - mitko);
        }
        else
        {
            Console.WriteLine("No {0}", mitko + vladko);
        }
    }
}