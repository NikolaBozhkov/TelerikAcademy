using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade cannot be negative number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Min grade cannot be negative number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade cannot be lower than the min grade!");
        }
        if (comments == null)
        {
            throw new ArgumentNullException("Comments cannot be null!");
        }
        if (comments == string.Empty)
        {
            throw new ArgumentException("Comments cannot be empty string!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
