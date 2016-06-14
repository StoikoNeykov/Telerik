namespace Humans.Models
{
    using System;

    /// <summary>
    /// Base + grade. Represent student
    /// </summary>
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.grade = 0;
        }

        public Student(string firstName, string lastName,int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grade cannot be negative number");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"{this.grade} {base.ToString()}"); 
        }
    }
}
