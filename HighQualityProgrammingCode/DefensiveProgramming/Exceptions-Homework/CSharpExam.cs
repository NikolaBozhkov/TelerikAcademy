using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("Score cannot be a negative number!");
        }
        if (score > 100)
        {
            throw new ArgumentOutOfRangeException("Score cannot be higher than 100!");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        // I moved the check directly in the constructor
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
