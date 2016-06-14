namespace School.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Teacher : People, ICommentable
    {
        private List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(disciplines);
            }
            private set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            if (this.disciplines.Count > 0)
            {
                foreach (var dis in this.disciplines)
                {
                    if (dis.Equals(discipline))
                    {
                        throw new ArgumentException("This discipline is already added!");
                    }
                }
            }

            this.disciplines.Add(discipline);
        }

        public bool RemoveDiscipline(Discipline discipline)
        {
            if (this.disciplines.Count > 0)
            {
                foreach (var dis in this.disciplines)
                {
                    if (dis.Equals(discipline))
                    {
                        this.disciplines.Remove(dis);
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
