using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student
{
    // Using directly properties for the sake of easier reading : )
    // I put only the property Group which contains the group number
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FN { get; set; }
    public string Tel { get; set; }
    public string Email { get; set; }
    public List<int> Marks { get; set; }
    public Group Group { get; set; }

    // A constructor
    public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks, Group group)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.FN = fn;
        this.Tel = tel;
        this.Email = email;
        this.Marks = marks;
        this.Group = group;
    }

    // Method for getting the marks of a student in a string variant
    public string GetMarks()
    {
        StringBuilder marks = new StringBuilder();
        marks.Append("[ ");
        foreach (int mark in this.Marks)
        {
            marks.AppendFormat("{0} ", mark);
        }

        marks.Append("]");
        return marks.ToString();
    }
}