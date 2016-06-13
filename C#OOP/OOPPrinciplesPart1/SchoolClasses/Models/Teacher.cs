namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SchoolClasses.Interfaces;

    public class Teacher : Person, IPerson, ICommentable
    {
        private string comment;

        private List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        private Teacher(Teacher teacherForCopy)
            : base(teacherForCopy.Name)
        {
            this.Disciplines = new List<Discipline>(teacherForCopy.Disciplines);
            this.Comment = teacherForCopy.Comment;
        }

        // can be move out in Person class but not every person have to be commentable
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

        public List<Discipline> Disciplines
        {
            get
            {
                var result = new List<Discipline>();
                if (this.Disciplines.Count > 0)
                {
                    foreach (var dis in this.Disciplines)
                    {
                        result.Add(dis.CopyDiscipline());
                    }
                }

                return result;
            }
            private set
            {
                this.disciplines = value;
            }
        }

        internal Teacher CopyTeacher()
        {
            return new Teacher(this);
        }

        public void AddDiscipline(Discipline discipline)
        {
            if (this.Disciplines.Count != 0)
            {
                foreach (var dis in this.Disciplines)
                {
                    if (dis.Equals(discipline))
                    {
                        throw new ArgumentException("This discipline is already added on the teacher!");
                    }
                }
            }

            this.Disciplines.Add(discipline);
        }

        public bool RemoveDiscipline(Discipline discipline)
        {
            if (this.Disciplines.Count == 0)
            {
                return false;
            }

            foreach (var dis in this.Disciplines)
            {
                if (dis.Equals(discipline))
                {
                    this.Disciplines.Remove(dis);
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object teacher)
        {
            if (!(teacher is Teacher))
            {
                return false;
            }

            var other = teacher as Teacher;
            if (this.Disciplines.SequenceEqual(other.Disciplines)
                && this.Comment == other.Comment
                && this.Comment == other.Comment)
            {
                return true;
            }

            return false;

        }
    }
}
