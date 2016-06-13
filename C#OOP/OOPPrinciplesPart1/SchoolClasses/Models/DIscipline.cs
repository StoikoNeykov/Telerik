namespace SchoolClasses.Models
{
    using SchoolClasses.Interfaces;
    using System;

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

        private Discipline(Discipline disciplineForCopy)
        {
            this.Name = disciplineForCopy.Name;
            this.NumberOfExercises = disciplineForCopy.NumberOfExercises;
            this.NumberOfLectures = disciplineForCopy.NumberOfLectures;
            this.Comment = disciplineForCopy.Comment;
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
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        internal Discipline CopyDiscipline()
        {
            return new Discipline(this);
        }

        public override bool Equals(object discipline)
        {
            if (!(discipline is Discipline))
            {
                return false;
            }

            var other = discipline as Discipline;
            if (this.Name == other.Name
                && this.NumberOfExercises == other.NumberOfExercises
                && this.NumberOfLectures == other.NumberOfLectures
                && this.Comment == other.Comment)
            {
                return true;
            }

            return false;
        }
    }
}
