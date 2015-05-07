namespace School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        // Fields
        private List<Discipline> disciplines;

        public string Comment { get; set; }

        // Constructors
        public Teacher(string name)
            : base(name)
        {
        }

        public Teacher(string name, List<Discipline> disciplines)
            : base(name)
        {
            this.disciplines = disciplines;
        }

        // Properties
        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(this.disciplines);
            }
        }

        // Methods
        public void AddDiscipline(Discipline discpline)
        {
            this.disciplines.Add(discpline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }
    }
}