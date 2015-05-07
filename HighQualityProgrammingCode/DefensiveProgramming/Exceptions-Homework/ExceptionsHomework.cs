using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("The array cannot be null!");
        }
        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                "Start index cannot be negative or bigger than the last index!");
        }
        if (count < 0 || count + startIndex > arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                "Count cannot be negative or to exceed the length of the array from the starting index!");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count < 0 || count > str.Length)
        {
            throw new ArgumentOutOfRangeException(
                "The count cannot be negative or bigger than the length of the string!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number < 2)
        {
            throw new ArgumentException("The checked number cannot be smaller than 2!");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        bool isTwentyThreePrime = CheckPrime(23);
        if (isTwentyThreePrime)
        {
            Console.WriteLine("23 is prime.");
        }
        else
        {
            Console.WriteLine("23 is not prime.");
        }

        bool isThirtyThreePrime = CheckPrime(33);
        if (isThirtyThreePrime)
        {
            Console.WriteLine("33 is prime.");
        }
        else
        {
            Console.WriteLine("33 is not prime.");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
