// Write a program that can solve these tasks:
// Reverses the digits of a number
// Calculates the average of a sequence of integers
// Solves a linear equation a * x + b = 0
// Create appropriate methods.
// Provide a simple text-based menu for the user to choose which task to solve.
// Validate the input data:
// The decimal number should be non-negative
// The sequence should not be empty
// a should not be equal to 0

using System;

public class MultiTaskProgram
{
    public static void ReverseDigits(decimal number)
    {
        string workNum = number.ToString(); // Converting the input num to string
        string newNum = string.Empty; // The new num in string

        // Filling the string
        for (int i = workNum.Length - 1; i >= 0; i--)
        {
            newNum += workNum[i];
        }

        number = decimal.Parse(newNum);
        Console.WriteLine("The new reversed number = {0}", number);
    }

    public static void AverageSum(int[] arr)
    {
        decimal avrgSum = 0;

        // The sum of all elements
        for (int i = 0; i < arr.Length; i++)
        {
            avrgSum += arr[i];
        }

        avrgSum /= arr.Length; // The average sum
        Console.WriteLine("The average sum = {0}", avrgSum);
    }

    public static void SolveLinearEq(decimal a, decimal b)
    {
        decimal x = -b / a;
        Console.WriteLine("X = {0}", x);
    }

    public static void ChooseTask()
    {
        Console.WriteLine("Please enter which method you want to use: ");
        Console.WriteLine("1.Reverse the digits of a number\n2.Calculate the average sum of a sequence of integers\n3.Solve linear equation");
        Console.WriteLine("Type \"exit\" to exit the program.");

        // Repeat asking for input while it is valid
        while (true)
        {
            Console.Write("Use the numbers to choose(1, 2 or 3): ");
            string choice = Console.ReadLine();
            if (choice == "exit")
            {
                break;
            }

            switch (choice)
            {
                case "1": 
                    { 
                        ValReverseDigits(); 
                    } 

                    break;
                case "2": 
                    { 
                        ValAverageSum(); 
                    }

                    break;
                case "3": 
                    { 
                        ValSolveLinearEq(); 
                    } 

                    break;
                default: 
                    { 
                        Console.WriteLine("Invalid input."); 
                    } 

                    break;
            }
        }
    }

    public static void ValReverseDigits()
    {
        while (true)
        {
            Console.Write("Please enter the number you want to have reversed: ");
            decimal num;
            string line = Console.ReadLine();
            if (decimal.TryParse(line, out num) && num >= 0)
            {
                ReverseDigits(num);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. The number must be non-negative!");
            }
        }
    }

    public static void ValAverageSum()
    {
        while (true)
        {
            Console.Write("Enter the lenght of the sequence: ");
            string line = Console.ReadLine();
            int length;
            if (int.TryParse(line, out length) && length > 0)
            {
                int[] array = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write("Enter element number {0}: ", i);
                    array[i] = int.Parse(Console.ReadLine());
                }

                AverageSum(array);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. The sequence should not be empty!");
            }
        }
    }

    public static void ValSolveLinearEq()
    {
        decimal a;
        decimal b;
        while (true)
        {
            Console.Write("Enter the constant A(a*x + b = 0): ");
            string lineA = Console.ReadLine();
            Console.Write("Enter the constant B: ");
            string lineB = Console.ReadLine();
            if (decimal.TryParse(lineA, out a) && decimal.TryParse(lineB, out b) && a != 0)
            {
                SolveLinearEq(a, b);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. \"A\" must not be equal to 0!");
            }
        }
    }

    public static void Main()
    {
        ChooseTask();
    }
}