using System;
using System.Threading;

public class Timer
{
    public event EventHandler TimePassed;
    public int Ticks { get; private set; }
    public int IntervalSeconds { get; private set; }

    public Timer(int intervalSeconds, int ticks)
    {
        this.Ticks = ticks;
        this.IntervalSeconds = intervalSeconds;
    }

    public void Run()
    {
        int ticks = this.Ticks;
        while (ticks > 0)
        {
            if (this.TimePassed != null)
            {
                TimePassed(this, new EventArgs());
            }

            Thread.Sleep(this.IntervalSeconds * 1000);
            ticks--;
        }
    }

    public static void OnTimePassed(object sender, EventArgs e)
    {
        Console.WriteLine("Current time: {0}", DateTime.Now);
    }

    public static void Main()
    {
        Timer timer = new Timer(3, 4);
        timer.TimePassed += OnTimePassed;
        timer.Run();
    }
}