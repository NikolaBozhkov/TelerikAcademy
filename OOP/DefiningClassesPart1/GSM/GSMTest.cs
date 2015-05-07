using System;

public class GSMTest
{
    // Fields
    private GSM[] array;

    // Constructors
    public GSMTest(GSM[] array)
    {
        this.array = array;
    }

    // Methods
    public void Test()
    {
        Console.WriteLine("GSMs Info");
        foreach (GSM gsm in this.array)
        {
            Console.WriteLine(gsm.ToString());
        }

        Console.WriteLine("Iphone4S Info");
        Console.WriteLine(GSM.Iphone4S.ToString());
    }
}