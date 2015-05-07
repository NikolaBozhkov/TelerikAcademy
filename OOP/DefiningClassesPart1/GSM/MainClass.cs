using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main()
    {
        // I hope I made this homework good and enjoyable : )
        // GSM test
        GSM[] gsmArray = 
        {
            new GSM("S800", "Samsung"),
            new GSM("3G", "Apple", 300),
            new GSM("GalaxyS", "Samsung", 800, new Battery("Samsung battery"), new Display(3.5))
        };

        GSMTest gsmTest = new GSMTest(gsmArray);
        gsmTest.Test();

        // Call history test
        List<Call> calls = new List<Call> 
            { 
                new Call(new DateTime(2014, 2, 24, 12, 14, 49), "12744522", 130),
                new Call(new DateTime(2014, 2, 24, 13, 13, 20), "12744522"),
                new Call(new DateTime(2014, 2, 24, 15, 12, 11), "12744522", 270),
                new Call(new DateTime(2014, 2, 24, 20, 25, 37), "12744522", 150)
            };

        GSMCallHistoryTest callHistoryTest = new GSMCallHistoryTest(calls);
        callHistoryTest.DisplayInfo();
        callHistoryTest.CalcAndPrintTotalPrice();
        callHistoryTest.DelLongestAndGetPrice();
        callHistoryTest.ClearAndPrintHistory();
    }
}