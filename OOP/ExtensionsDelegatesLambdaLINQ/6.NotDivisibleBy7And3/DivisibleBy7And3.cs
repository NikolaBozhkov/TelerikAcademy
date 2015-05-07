using System;
using System.Linq;

public class DivisibleBy7And3
{
    public static void UseExtensions(int[] array)
    {
        var found = array.Where(num => num % 3 == 0 && num % 7 == 0);

        foreach (var item in found)
        {
            Console.WriteLine(item);
        }
    }

    public static void UseLinqQuery(int[] array)
    {
        var found =
            from num in array
            where num % 3 == 0 && num % 7 == 0
            select num;

        foreach (var item in found)
        {
            Console.WriteLine(item);
        }
    }

    public static void Main()
    {
        int[] array = new int[] { 1, 2, 3, 21, 42, 84, 5, 6, 8 };
        UseExtensions(array);
        Console.WriteLine(new string('-', 20));
        UseLinqQuery(array);
    }
}