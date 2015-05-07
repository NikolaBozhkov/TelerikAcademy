namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Ordering
    {
        public static void Main()
        {
            IEnumerable<Student> students = new List<Student>()
            {
                new Student("Pesho", "Ivanov", 7),
                new Student("Ivan", "Georgiev", 11),
                new Student("Vladimir", "Putin", 12),
                new Student("Gerogi", "Lesov", 2),
                new Student("Stanimir", "Stenev", 1),
            };

            students = students.OrderBy(student => student.Grade).ToList();

            IEnumerable<Worker> workers = new List<Worker>()
            {
                new Worker("Pesho", "Georgiev", 1000, 7),
                new Worker("Ivan", "Ivanov", 1200, 8),
                new Worker("Stanimir", "Putin", 1400, 8),
                new Worker("Vladimir", "Lesov", 700, 6),
                new Worker("Gerogi", "Stenev", 2000, 8),
            };

            workers = workers.OrderByDescending(worker => worker.MoneyPerHour()).ToList();

            // Merging as Human, as they both derive from it
            var mergedList = students.Concat<Human>(workers);

            mergedList = mergedList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var human in mergedList)
            {
                Console.WriteLine(human.FirstName + " " +  human.LastName);
            }
        }
    }
}
