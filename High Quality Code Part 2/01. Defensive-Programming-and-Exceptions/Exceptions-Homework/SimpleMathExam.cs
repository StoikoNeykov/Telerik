using System;

public class SimpleMathExam : Exam
{
    public int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value <= 0)
            {
                this.problemsSolved = 0;
            }
            else if (value >= 10)
            {
                this.problemsSolved = 10;
            }
            else
            {
                this.problemsSolved = value;
            }
        }
    }

    public override ExamResult Check()
    {
        // refactored a lil but still looks wrong as ....

        switch (this.ProblemsSolved)
        {
            case 0: return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1: return new ExamResult(4, 2, 6, "Average result: nothing done.");
            case 2: return new ExamResult(6, 2, 6, "Average result: nothing done.");
            default: return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
        }
    }
}
