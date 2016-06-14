namespace SchoolClasses.Models
{
    using SchoolClasses.Interfaces;
    using System;

    /// <summary>
    /// Represent school discipline. Hold name, number of lectures and number of exercises.
    /// Name is readonly.
    /// </summary>
    public class Discipline : ICommentable
    {
        private string name;

        private int numberOfLectures;

        private int numberOfExercises;

        private string comment;

        public Discipline(string name)
        {
            this.Name = name;
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
            : this(name)
        {
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of Discipline have to be set!");
                }

                this.name = value;
            }
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

        public string Comment
        {
            get
            {
                if (string.IsNullOrEmpty(this.comment))
                {
                    return "Still no comments for this discipline!";
                }

                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string FullString()
        {
            return string.Format("{0}{1} Number of lectures: {2}{1} Number of exercises: {3}",
                this.Name,
                Environment.NewLine,
                this.NumberOfLectures,
                this.NumberOfExercises);
        }
    }
}
