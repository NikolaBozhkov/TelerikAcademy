using System;
using System.Linq;

public class StudentGroups
{
    public static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Gosho Ivanov", "Nicks"),
            new Student("Ivan Yordanov", "Yankies"),
            new Student("Ivan Stefanov", "Snickers"),
            new Student("Aleksandra Danailova", "Nicks"),
            new Student("Petur Bodrev", "Snickers")
        };

        // Task 18
        Console.WriteLine("---Task18---");
        var groups =
            from student in students
            group student by student.GroupName into newGroup
            orderby newGroup.ToArray().Length descending
            select newGroup;

        
        foreach (var group in groups)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Group name: {0}", group.Key);
            Console.ResetColor();

            foreach (var student in group)
            {
                // I am printing the group name for the check, if it works
                Console.WriteLine("{0}, {1}", student.FullName, student.GroupName);
            }
        }

        Console.WriteLine(new string('-', 70));

        // Task 19, same with extensions
        Console.WriteLine("---Task19---");
        var groupsTask19 = students.GroupBy(student => student.GroupName)
            .OrderByDescending(group => group.ToArray().Length);

        foreach (var group in groupsTask19)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Group name: {0}", group.Key);
            Console.ResetColor();

            foreach (var student in group)
            {
                Console.WriteLine("{0}, {1}", student.FullName, student.GroupName);
            }
        }

        Console.WriteLine(new string('-', 70));
    }
}