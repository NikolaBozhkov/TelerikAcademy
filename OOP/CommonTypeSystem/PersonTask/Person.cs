namespace PersonTask
{
    public class Person
    {
        // Automated properties
        public string Name { get; set; }
        public byte? Age { get; set; }

        // Constructors
        public Person(string name, byte? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}", this.Name, this.Age == null ? "not defined" : this.Age.ToString());
        }
    }
}