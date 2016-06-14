namespace School.Models
{
    using Interfaces;
    
    public class Student : People, ICommentable
    {
        private int classId;

        public Student(string name)
            : base(name)
        {
        }

        public int ClassId
        {
            get
            {
                return this.classId;
            }

            internal set
            {
                this.classId = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
