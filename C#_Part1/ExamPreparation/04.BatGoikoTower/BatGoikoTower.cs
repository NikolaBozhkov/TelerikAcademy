using System;

class BatGoikoTower
{
    static void Main()
    {
        // Get the height
        int height = int.Parse(Console.ReadLine());

        // Draw top of the tower
        Console.WriteLine("{0}/\\{0}", new string('.', height - 1));

        // Draw the rest
        bool dotsDrawn = true;
        for (int i = height - 2, currSlash = 0, middleElem = 2; i >= 0; i--, middleElem += 2)
        {
            if (dotsDrawn == true)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', i), new string('-', middleElem));
                currSlash++;
                dotsDrawn = false;
            }
            else
            {
                for (int rows = 0; rows < currSlash && i >= 0; rows++, i--, middleElem += 2)
                {
                    Console.WriteLine("{0}/{1}\\{0}", new string('.', i), new string('.', middleElem));
                }
                i++;
                middleElem -= 2;
                dotsDrawn = true;
            }
        }
    }
}