using System;

class Garden
{
    static void Main()
    {
        decimal sum = 0;
        int areaUsed = 0;
        int area = 250;
        decimal tomato = decimal.Parse(Console.ReadLine()) * 0.5m;
        int tomatoArea = int.Parse(Console.ReadLine());
        areaUsed += tomatoArea;
        sum += tomato;
        decimal cucumber = decimal.Parse(Console.ReadLine()) * 0.4m;
        int cucumberArea = int.Parse(Console.ReadLine());
        areaUsed += cucumberArea;
        sum += cucumber;
        decimal potato = decimal.Parse(Console.ReadLine()) * 0.25m;
        int potatoArea = int.Parse(Console.ReadLine());
        areaUsed += potatoArea;
        sum += potato;
        decimal carrot = decimal.Parse(Console.ReadLine()) * 0.6m;
        int carrotArea = int.Parse(Console.ReadLine());
        areaUsed += carrotArea;
        sum += carrot;
        decimal cabbage = decimal.Parse(Console.ReadLine()) * 0.3m;
        int cabbageArea = int.Parse(Console.ReadLine());
        areaUsed += cabbageArea;
        sum += cabbage;
        decimal beans = decimal.Parse(Console.ReadLine()) * 0.4m;
        sum += beans;
        int leftOver = area - areaUsed;
        Console.WriteLine("Total costs: {0:F2}", sum);
        if (leftOver > 0)
        {
            Console.WriteLine("Beans area: {0}", leftOver);
        }
        else if (leftOver == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}