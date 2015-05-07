using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("Problems solved cannot be a negative number.");
        }
        if (problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("Problems solved cannot be a bigger than 10.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: 1 problem solved.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Good result: 2 problems solved.");
        }
        else
        {
            throw new ArgumentException("Invalid number of solved problems.");
        }
    }
}
