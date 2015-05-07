using System;
using System.Text;

public class ExtensionExample
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder("Just a test.");
        Console.WriteLine(sb.Substring(1, 3));
    }
}