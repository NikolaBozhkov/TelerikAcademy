namespace School
{
    using System.Collections.Generic;

    public class Class : ICommentable
    {
        // Fields and the automatic ID property
        private List<Student> students;
        private List<Teacher> teachers;

        public string ClassID { get; private set; }

        public string Comment { get; set; }

        // Constructors
        public Class(List<Teacher> teachers, string classID)
        {
            this.teachers = teachers;
            this.ClassID = classID;
        }

        public Class(List<Teacher> teachers, string classID, List<Student> students)
            : this(teachers, classID)
        {
            this.students = students;
        }

        // Properties
        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            }
        }

        // Methods
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }
    }
}