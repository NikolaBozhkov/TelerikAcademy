namespace _1_3.StudentsTasks
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        // Automated properties
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ulong SSN { get; set; }

        public string Address { get; set; }

        public uint PhoneNumber { get; set; }

        public string Email { get; set; }

        public uint Course { get; set; }

        public Specialty Specialty { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        // Constructors 
        public Student(string firstName, string middleName, string lastName, ulong ssn, string address, uint phoneNumber, string email, uint course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        // Methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }

            return this.FirstName == student.FirstName &&
                this.LastName == student.LastName &&
                this.SSN == student.SSN;
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(Student.Equals(first, second));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0} {1} {2}\nAddress: {3}\nPhone number: {4}\nSSN: {5}\nUniversity: {6}", 
                this.FirstName, this.MiddleName, this.LastName, this.Address, this.PhoneNumber, this.SSN, this.University);
        }

        // Cloning
        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, 
                this.PhoneNumber, this.Email, this.Course, this.Specialty, this.University, this.Faculty);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        // Comparing
        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            if (this.MiddleName != other.MiddleName)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }

            if (this.LastName != other.LastName)
            {
                return this.LastName.CompareTo(other.LastName);
            }

            if (this.SSN != other.SSN)
            {
                return this.SSN.CompareTo(other.SSN);
            }

            return 0;
        }
    }
}