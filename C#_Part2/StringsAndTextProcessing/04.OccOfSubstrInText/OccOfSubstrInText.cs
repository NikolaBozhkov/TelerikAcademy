// Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).

using System;

public class OccOfSubstrInText
{
    public static void Main()
    {
        int count = 0;
        int index = -1;
        string target = "in";
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        text = text.ToLower();
        index = text.IndexOf(target, index + 1);

        // Normal cycle for counting occurunces
        while (index != -1)
        {            
            count++;
            index = text.IndexOf(target, index + 1);
        }

        Console.WriteLine(count);
    }
}