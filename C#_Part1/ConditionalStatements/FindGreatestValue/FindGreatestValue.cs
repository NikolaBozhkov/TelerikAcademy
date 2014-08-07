// Write a program that finds the greatest of given 5 variables.

using System;
using System.Collections.Generic;
using System.Linq;

public class FindGreatestValue
{
    public static void Main()
    {        
        Console.WriteLine("Please enter 5 variables on separate lines: ");          
        decimal num;
        List<decimal> list = new List<decimal>(); 
        while (list.Count < 5)
        {
            string line = Console.ReadLine();
            if (decimal.TryParse(line, out num))
            {
                list.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input.Try again(your record is not lost).");
            }
        }   
     
        Console.WriteLine("The biggest variable is: {0}", list.Max());                    
    }
}