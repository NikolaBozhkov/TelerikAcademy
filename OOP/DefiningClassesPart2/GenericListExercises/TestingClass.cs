using System;

public class TestingClass
{
    public static void Main()
    {
        GenericList<int> list = new GenericList<int>(3);
        list.Add(5);
        list.Add(6);
        list.Add(7);
        list.RemoveAt(1);
        Console.WriteLine(list.ToString());
        list.Insert(1, 6);
        Console.WriteLine(list.ToString());
        list.Add(5);
        Console.WriteLine(list.ToString());
        Console.WriteLine(list.Max());
        Console.WriteLine(list.Min());
    }
}