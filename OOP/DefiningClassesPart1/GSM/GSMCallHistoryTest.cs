using System;
using System.Collections.Generic;

public class GSMCallHistoryTest
{
    // Fields
    private GSM testGSM = new GSM("test", "test");

    // Constructors
    public GSMCallHistoryTest(List<Call> callHistory)
    {
        foreach (Call call in callHistory)
        {
            this.testGSM.AddCallToHistory(call);
        }
    }

    // Methods
    public void DisplayInfo()
    {
        foreach (Call call in this.testGSM.CallHistory)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(call.ToString());
            Console.WriteLine(new string('-', 20));
        }
    }

    public void CalcAndPrintTotalPrice()
    {
        Console.WriteLine(this.testGSM.PriceOfCalls(0.37M));
    }

    public void DelLongestAndGetPrice()
    {
        Call longestCall = new Call(DateTime.Now, string.Empty, 0);
        foreach (Call call in this.testGSM.CallHistory)
        {
            if (call.Duration > longestCall.Duration)
            {
                longestCall = call;
            }
        }

        this.testGSM.RemoveCallFromHistory(longestCall);
        this.CalcAndPrintTotalPrice();
    }

    public void ClearAndPrintHistory()
    {
        this.testGSM.ClearCallHistory();
        this.DisplayInfo();
    }
}