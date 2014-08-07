// Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.

using System;

public class ElemIndexMultBy5
{
    public static void Main()
    {
        int[] Array = new int[20];
        for (int i = 0; i < 20; i++)
        {
            Array[i] = i * 5;
            Console.Write(Array[i] + "  ");
        }
    }
}