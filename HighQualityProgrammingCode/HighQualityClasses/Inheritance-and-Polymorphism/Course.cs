namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students = new List<string>();

        public Course(string name)
        {
            this.Name = name;
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot be less than 3 characters.");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teacher name cannot be null.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Teacher name cannot be less than 3 characters.");
                }

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                    {
                        throw new ArgumentException("Teacher name can contain only letters and white spaces.");
                    }

                    this.teacherName = value;
                }
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of students cannot be null.");
                }

                this.students = value;
            }
        }

        protected virtual string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(" { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
