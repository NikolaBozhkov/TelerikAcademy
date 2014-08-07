// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

using System;

public class CheckBrackets
{
    public static bool CheckExprBrackets(string expr)
    {
        int count = 0;

        for (int i = 0; i < expr.Length; i++)
        {
            // The first two checks are obvious
            // The third check is to catch if there
            // is a closing bracket, without an opening
            if (expr[i] == '(')
            {
                count++;
            }

            if (expr[i] == ')')
            {
                count--;
            }

            if (count < 0)
            {
                return false;
            }
        }

        return count == 0;
    }

    public static void Main()
    {
        Console.WriteLine(CheckExprBrackets("(a + b) + 2 * )a - 2( + (3 + a)"));
        Console.WriteLine(CheckExprBrackets("((a + b) + 2 * (3 + a) + 2)"));
    }
}