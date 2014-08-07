// Which of the following values can be assigned to a variable of type float 
// and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?

using System;

public class FloatAndDouble
{
    public static void Main()
    {
        float justFloat = 12.345f;
        float justFloat2 = 3456.091f;
        double justDouble = 34.567839023;
        double justDouble2 = 8923.1234857;

        Console.WriteLine("Floats:\n{0}\n{1}\nDouble:\n{2}\n{3}", 
            justFloat, justFloat2, justDouble, justDouble2);
    }
}
