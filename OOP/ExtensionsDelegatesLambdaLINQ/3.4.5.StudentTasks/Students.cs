using System;
using System.Linq;
using System.Collections.Generic;

public class Students
{
    public static void ForEach<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Sorry that these tasks are not so pretty I re-edited them a couple of times
    public static void Main()
    {
        var students = new[]
        {
            new { FirstName = "Atanas", LastName = "Georgiev", Age = 25 },
            new { FirstName = "Atanas", LastName = "Bermundov", Age = 24 },
            new { FirstName = "Boqn", LastName = "Atanasov", Age = 30 }
        };

        // Task 3
        var found =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;

        ForEach(found);

        Console.WriteLine(new string('-', 70));

        // Task 4
        var foundByName =
            from student in students
            where student.Age >= 18 && student.Age <= 24
            select student.FirstName + " " + student.LastName;

        ForEach(foundByName);

        Console.WriteLine(new string('-', 70));

        // Task 5, extensions
        var sorted = students.OrderByDescending(student => student.FirstName).
            ThenByDescending(student => student.LastName);

        ForEach(sorted);

        Console.WriteLine(new string('-', 70));

        // Task 5, query
        var sortedQuery =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

        ForEach(sortedQuery);
    }
}