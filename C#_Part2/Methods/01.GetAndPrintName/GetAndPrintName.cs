﻿// Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;

public class GetAndPrintName
{
    public static void GetPrintName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }

    public static void Main()
    {
        GetPrintName();
    }
}