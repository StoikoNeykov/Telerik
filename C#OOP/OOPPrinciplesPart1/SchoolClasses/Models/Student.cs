namespace SchoolClasses.Models
{
    using System;
    using SchoolClasses.Interfaces;

    /// <summary> 
    /// Represent student. Have own name. ClassIdent and NumberInClass can be set with Add him/her
    /// in specific class. NumberInClass is unique. Student can be part of 1 class only! 
    /// </summary>
    public class Student : Person, IPerson, ICommentable
    {
        private string comment;

        private int numberInClass;

        private string classIdent;

        public Student(string name)
            : base(name)
        {

        }

        public string Comment
        {
            get
            {
                if (string.IsNullOrEmpty(this.comment))
                {
                    return "Still no comments for this student!";
                }
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public int NumberInClass
        {
            get
            {
                return this.numberInClass;
            }
            internal set
            {
                this.numberInClass = value;
            }
        }

        public string ClassIdent
        {
            get
            {
                return this.classIdent;
            }
            internal set
            {
                this.classIdent = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string FullString()
        {
            return string.Format("{0}:{3} class: {1}{3} number in class: {2}",
                this.Name,
                this.ClassIdent ?? "none",
                this.NumberInClass,
                Environment.NewLine);
        }
    }
}
