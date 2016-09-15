using System;

public class CSharpExam : Exam
{
    public int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }
        private set
        {
            if (value < 0 || 100 < value)
            {
                // for some reason
                throw new ArgumentOutOfRangeException("Score", "Score should be in range 0-100!");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
