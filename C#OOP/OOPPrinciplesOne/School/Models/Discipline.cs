namespace School.Models
{
    using System;

    using Interfaces;

    public class Discipline : SchoolItem, ICommentable
    {
        private int numberOfLectures;

        private int numberOfExercises;

        public Discipline(string name)
            :base(name)
        {

        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
            :base(name)
        {
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }
        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("NumberOfLectures cannot be negative number!");
                }
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("NumberOfExercises cannot be negative number!");
                }

                this.numberOfExercises = value;
            }
        }

        public override string ToString()
        {
            return this.Ident;
        }
    }
}
