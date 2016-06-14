namespace SchoolClasses.Models
{

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent school system. Mainly contains list of classes and name
    /// </summary>
    public class School
    {
        private string name;

        private List<ClassOfStudents> classes;

        public School(string name)
        {
            this.Name = name;
            this.Classes = new List<ClassOfStudents>();
        }

        public List<ClassOfStudents> Classes
        {
            get
            {
                return new List<ClassOfStudents>(this.classes);
            }
            set
            {
                this.classes = value;
            }
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
                    throw new ArgumentException("Invalid school name!");
                }

                this.name = value;
            }
        }

        public void AddClass(ClassOfStudents classAdd)
        {
            if (!(this.classes.Count == 0))
            {
                foreach (var cls in this.classes)
                {
                    if (cls.Equals(classAdd))
                    {
                        throw new ArgumentException("This class already added in the school!");
                    }
                }
            }

            this.classes.Add(classAdd);
        }

        public bool RemoveClass(ClassOfStudents classRemove)
        {
            if (this.classes.Count == 0)
            {
                return false;
            }

            foreach (var cls in this.classes)
            {
                if (cls.Equals(classRemove))
                {
                    this.classes.Remove(cls);
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
            return string.Format("{0}{1}Classes:{1}{2}",
                this.Name,
                Environment.NewLine,
                string.Join(Environment.NewLine, this.Classes));
        }
    }
}
