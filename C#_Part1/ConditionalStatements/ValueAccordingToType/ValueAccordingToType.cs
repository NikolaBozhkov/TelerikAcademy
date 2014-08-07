// Write a program that, depending on the user's choice inputs int, double or string variable. 
// If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end.
// The program must show the value of that variable as a console output. Use switch statement.

using System;

public class ValueAccordingToType
{
    public static void Main()
    {
        Console.Write("Please enter a variable(int, double, string): ");
        string line = Console.ReadLine();
        int intnum;
        double doublenum = 0;
        int switcher = 0;
        if (int.TryParse(line, out intnum))
        {
            switcher = 1;
        }
        else if (double.TryParse(line, out doublenum))
        {
            switcher = 2;
        }

        switch (switcher)
        {                
            case 0:
                Console.WriteLine("The new value of {0} is: {1}", line, line + "*");
                break;
            case 1:
                Console.WriteLine("The new value of {0} is: {1}", intnum, intnum + 1);
                break;
            case 2:
                Console.WriteLine("The new value of {0} is: {1}", doublenum, doublenum + 1);
                break;
        }                 
    }
}