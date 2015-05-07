namespace School
{
    public class Discipline : ICommentable
    {
        // No validation required here, as the name can be "C#" for example
        public string Name { get; private set; }

        public uint NumberOfLectures { get; private set; }

        public uint NumberOfExcercises { get; private set; }

        public string Comment { get; set; }

        // Constructors
        public Discipline(string name)
        {
            this.Name = name;
        }

        public Discipline(string name, uint numberOfLectures, uint numberOfExcercises)
            : this(name)
        {
            this.NumberOfExcercises = numberOfExcercises;
            this.NumberOfLectures = numberOfLectures;
        }
    }
}