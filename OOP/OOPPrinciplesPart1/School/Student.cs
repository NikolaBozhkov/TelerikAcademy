namespace School
{
    using System;

    public class Student : Person, ICommentable
    {
        public ulong ClassNumber { get; private set; }

        public string Comment { get; set; }
     
        // Constructor
        public Student(string name)
            : base(name)
        {
        }

        public Student(string name, ulong classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }
    }
}