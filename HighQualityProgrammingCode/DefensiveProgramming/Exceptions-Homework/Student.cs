using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    public IList<Exam> Exams { get; set; }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        // Moved the checks into the properties and set fields
        // Exams can be null so I left it with the automated property
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName 
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("First name cannot be null!");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain less than 3 characters!");
            }

            this.firstName = value;
        } 
    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Last name cannot be null!");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain less than 3 characters!");
            }

            this.lastName = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Exams cannot be null in order to check exams!");
        }

        // Removed the check for 0 exams, cuz I think the result should be an empty list
        // if the student has no exams and not null.
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Exams cannot be null in order to calculate average!");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Cannot calculate average exam result on empty exams!");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
