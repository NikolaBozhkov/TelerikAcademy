// * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
// N = 10  N! = 3628800  2
// N = 20  N! = 2432902008176640000  4
// Does your program work for N = 50 000?
// Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

using System;

class TrailingZeros
{
    static void Main()
    {
        // Причината е следната, четно X четно или четно X нечетно = четно,
        // = > 5!, 10!, 15!... = четно X 5/10(5x2)/15(5x3)... A 5 X четно = ...0
        // Единствено 5 X числа завършващи на 0 не дава число с още една 0, но 4/14/24.. X 1/2/3/11/12/13... != ...0
        // = > За всеки един множител кратен на 5 добавяме една 0
        // Всички факториели са четни числа, тоест можем да представим 10!(например) като някакво число k X кратните на 5
        // 10! = k X 5 X 10, обаче 25! = k X 5 X 10 X 15 X 20 X 25 = k X 5 X 5x2 X 5x3 X 5x4 X 5x5(още една 5ца) = > 6 нули
        // = > колкото 5ци имаме в разлагането на факториела, толкова и нули : )
        // Надявам се да се е разбрала логиката ми !
        // And the code - >
        Console.Write("Enter \"N\": ");
        int zeros = 0;
        int n = int.Parse(Console.ReadLine());
        int copy = n;
        while (copy >= 5)
        {
            copy /= 5;
            zeros += copy;
        }
        Console.WriteLine("{0}! has {1} trailing zeros", n, zeros);
    }
}