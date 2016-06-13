namespace SchoolClasses.Models
{
    using SchoolClasses.Interfaces;

    /// <summary> 
    /// Represent student 
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

        // making copy of student 
        private Student(Student studentForCopy)
            : base (studentForCopy.Name)
        {
            this.NumberInClass = studentForCopy.NumberInClass;
            this.ClassIdent = studentForCopy.ClassIdent;
            this.Comment = studentForCopy.Comment;
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

        public override bool Equals(object student)
        {
            if (!(student is Student))
            {
                return false;
            }

            var other = student as Student;
            if (this.Name == other.Name
                && this.NumberInClass == other.NumberInClass
                && this.ClassIdent == other.ClassIdent)
            {
                return true;
            }

            return false;
        }

        internal Student CopyStudent()
        {
            return new Student(this);
        }
    }
}
