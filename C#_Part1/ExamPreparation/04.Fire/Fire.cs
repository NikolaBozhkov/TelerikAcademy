using System;

class Fire
{
    static void Main()
    {
        // Take input
        int width = int.Parse(Console.ReadLine());

        // Draw top(first)
        for (int i = (width / 2) - 1, middle = 0; i >= 0; i--, middle += 2)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', i), new string('.', middle));
        }

        // Draw top(second)
        for (int i = 0, middle = width - 2; i < width / 4; i++, middle -= 2)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', i), new string('.', middle));
        }

        // Draw middle
        Console.WriteLine(new string('-', width));

        // Draw bottom
        for (int i = width / 2, dots = 0; i > 0; i--, dots++)
        {
            Console.WriteLine("{0}{1}{2}{0}", new string('.', dots), new string('\\', i), new string('/', i));
        }
    }
}