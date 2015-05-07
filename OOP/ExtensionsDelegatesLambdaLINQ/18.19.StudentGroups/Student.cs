using System;

public class Student
{
    // Properties
    public string FullName { get; set; }
    public string GroupName { get; set; }

    // Constructor
    public Student(string fullName, string groupName)
    {
        this.FullName = fullName;
        this.GroupName = groupName;
    }
}