using System;
using System.Collections.Generic;
using System.Linq;

public class ExampleClass
{
    public static void Main()
    {
        // Example students
        List<Student> students = new List<Student>()
        {
            new Student("Gosho", "Petrov", "259606121", "028581653", "student1@abv.bg", new List<int>() { 5, 3, 3, 2, 4, 5 }, new Group(2, "History")),
            new Student("Pesho", "Petrov", "158307433", "028682377", "student2@abv.bg", new List<int>() { 6, 5, 4, 4, 4, 5 }, new Group(1, "Mathematics")),
            new Student("Ivan", "Asenov", "252305387", "038188874", "student3@gmail.com", new List<int>() { 2, 3, 2, 5, 5, 5 }, new Group(3, "Iconomics")),
            new Student("Georgi", "Iordanov", "216104713", "049782255", "student4@yahoo.com", new List<int>() { 2, 3, 4, 4, 4, 5 }, new Group(2, "Mathematics")),
            new Student("Stefan", "Ivanov", "756306232", "027183466", "student5@yahoo.com", new List<int>() { 2, 5, 5, 5, 6, 5 }, new Group(3, "History")),
            new Student("Gabriela", "Georgieva", "851306567", "059983476", "student6@gmail.com", new List<int>() { 6, 2, 3, 2, 6, 5 }, new Group(1, "Mathematics")),
            new Student("Anastasiq", "Bojidarova", "211303478", "098877433", "student7@abv.bg", new List<int>() { 3, 6, 6, 6, 6, 5 }, new Group(2, "History"))
        };

        // Task 9, sorry for the bad naming of the found list, just, many tasks
        Console.WriteLine("---Task9---");
        var foundTask9 =
            from student in students
            where student.Group.GroupNumber == 2
            orderby student.FirstName
            select student;

        foreach (var student in foundTask9)
        {
            Console.WriteLine("{0}, group: {1}", student.FirstName, student.Group.GroupNumber);
        }

        Console.WriteLine(new string('-', 70));

        // Task 10, Task 9 with extensions
        Console.WriteLine("---Task10---");
        var foundTask10 = students.FindAll(student => student.Group.GroupNumber == 2)
            .OrderBy(student => student.FirstName);
        foreach (var student in foundTask10)
        {
            Console.WriteLine("{0}, group: {1}", student.FirstName, student.Group.GroupNumber);
        }

        Console.WriteLine(new string('-', 70));

        // Task 11
        Console.WriteLine("---Task11---");
        var foundTask11 =
            from student in students
            where student.Email.EndsWith("abv.bg")
            select student;

        foreach (var student in foundTask11)
        {
            Console.WriteLine("{0}, email: {1}", student.FirstName, student.Email);
        }

        Console.WriteLine(new string('-', 70));

        // Task 12, I am checking if the code is 02
        Console.WriteLine("---Task12---");
        var foundTask12 =
            from student in students
            where student.Tel.StartsWith("02")
            select student;

        foreach (var student in foundTask12)
        {
            Console.WriteLine("{0}, telephone: {1}", student.FirstName, student.Tel);
        }

        Console.WriteLine(new string('-', 70));

        // Task 13
        Console.WriteLine("---Task13---");
        var foundTask13 =
            from student in students
            where student.Marks.Contains(6)
            select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

        foreach (var student in foundTask13)
        {
            Console.WriteLine("{0}, marks: {1}", student.FullName, student.Marks);
        }

        Console.WriteLine(new string('-', 70));

        // Task 14, Task 13 with extensions and we search for students with 2 marks "2"
        Console.WriteLine("---Task14---");
        var foundTask14 = students.Where(student => student.Marks.Count(mark => mark == 2) == 2)
            .Select(student => new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() });

        foreach (var student in foundTask14)
        {
            Console.WriteLine("{0}, marks: {1}", student.FullName, student.Marks);
        }

        Console.WriteLine(new string('-', 70));

        // Task 15
        Console.WriteLine("---Task15---");
        var foundTask15 =
            from student in students
            where student.FN.Substring(4, 2) == "06"
            select student;

        foreach (var student in foundTask15)
        {
            Console.WriteLine("{0}, year: {1}", student.FirstName, student.FN.Substring(4, 2));
        }

        Console.WriteLine(new string('-', 70));

        // Task 16
        Console.WriteLine("---Task16---");
        Group[] groups = new Group[]
        {
            new Group(2, "Mathematics"),
            new Group(3, "History"),
            new Group(8, "Medicine"),
            new Group(5, "Iconomics"),
        };

        var foundTask16 =
            from student in students
            join _group in groups on student.Group.DepartmentName equals _group.DepartmentName
            where _group.DepartmentName == "Mathematics"
            select student;

        foreach (var student in foundTask16)
        {
            Console.WriteLine("{0}, department: {1}", student.FirstName, student.Group.DepartmentName);
        }

        Console.WriteLine(new string('-', 70));
    }
}