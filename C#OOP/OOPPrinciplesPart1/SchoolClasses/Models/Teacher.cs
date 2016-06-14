namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolClasses.Interfaces;

    /// <summary>
    /// Represent teacher as person. Hold name and list of disciplines
    /// </summary>
    public class Teacher : Person, IPerson, ICommentable
    {
        private string comment;

        private List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public string Comment
        {
            get
            {
                if (string.IsNullOrEmpty(this.comment))
                {
                    return "Still no comment available for this teacher!";
                }
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
                return new List<Discipline>(this.disciplines);
            }
            private set
            {
                this.disciplines = value;
            }
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

        public override string ToString()
        {
            return this.Name;
        }

        public string FullString()
        {
            var separator = Environment.NewLine;
            return string.Format("{0}:{1}Disciplines:{1}{2}",
                this.Name,
                Environment.NewLine,
                string.Join(separator, this.Disciplines));
        }
    }
}
