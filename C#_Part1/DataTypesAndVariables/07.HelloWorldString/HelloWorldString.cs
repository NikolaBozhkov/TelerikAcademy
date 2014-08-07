// Declare two string variables and assign them with “Hello” and “World”.
// Declare an object variable and assign it with the concatenation of the first two
// variables (mind adding an interval). Declare a third string variable and initialize
// it with the value of the object variable (you should perform type casting).

using System;

public class HelloWorldString
{
    public static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object concat = string.Format("{0} {1}", hello, world);
        string result = (string)concat;

        Console.WriteLine(result);
    }
}
