namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class EntryPoint
    {
        static void Main()
        {
            // I have no time to make the "aplication" beautiful
            // I only tested the db : )
            var db = new StudentSystemDbContext();

            var student = new Student()
            {
                Name = "Pesho",
                Number = 38
            };

            db.Students.Add(student);
            db.SaveChanges();

            var pesho = db.Students.FirstOrDefault();
            Console.WriteLine(pesho.Name);

            var course = new Course()
            {
                Name = "Databases"
            };

            var homework = new Homework()
            {
                Content = "Very hard",
                TimeSent = DateTime.Now,
                Student = pesho
            };

            course.Students.Add(pesho);
            db.Courses.Add(course);
            db.Homeworks.Add(homework);
            db.SaveChanges();

            var homeworkByCourse = db.Homeworks.FirstOrDefault(h => h.Course.Name == "Databases");

            Console.WriteLine("Homework content: " + homeworkByCourse.Content);
        }
    }
}
