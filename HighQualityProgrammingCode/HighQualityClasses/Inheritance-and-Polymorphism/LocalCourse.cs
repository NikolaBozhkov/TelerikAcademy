using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Lab cannot be null.");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Lab name cannot less than 2 characters.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("; Lab = {0}", this.Lab);
            result.Append(" }");

            return result.ToString();
        }
    }
}
