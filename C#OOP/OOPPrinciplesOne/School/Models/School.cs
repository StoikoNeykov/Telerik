namespace School.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class School : SchoolItem, ICommentable
    {
        private List<ClassOfStudents> classes;

        public School(string name)
            : base(name)
        {
            this.Classes = new List<ClassOfStudents>();
        }

        public List<ClassOfStudents> Classes
        {
            get
            {
                return new List<ClassOfStudents>(this.classes);
            }
            private set
            {
                this.classes = value;
            }
        }

        public void AddClass(ClassOfStudents aClass)
        {
            if (this.classes.Count > 0)
            {
                foreach (var cls in this.classes)
                {
                    if (cls.Equals(aClass))
                    {
                        throw new ArgumentException("Already added!");
                    }
                }

                this.classes.Add(aClass);
            }
        }

        public bool RemoveClass(ClassOfStudents aClass)
        {
            if (this.classes.Count > 0)
            {
                foreach (var cls in this.classes)
                {
                    if (cls.Equals(aClass))
                    {
                        this.classes.Remove(cls);
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.Ident;
        }
    }
}
