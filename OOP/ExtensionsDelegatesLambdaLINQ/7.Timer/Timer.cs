using System;
using System.Linq;
using System.Threading;

public class Timer
{
    // I am using the build-in delegate Action and interval and duration 
    // for the execution of the method
    public static void RepeatMethod(Action method, int intervalSeconds, int ticks)
    {
        while (ticks > 0)
        {
            method();
            Thread.Sleep(intervalSeconds * 1000);
            ticks--;
        }
    }

    public static void PrintTime()
    {
        Console.WriteLine("Current time: {0}", DateTime.Now);
    }

    public static void Main()
    {
        RepeatMethod(PrintTime, 3, 3);
    }
}