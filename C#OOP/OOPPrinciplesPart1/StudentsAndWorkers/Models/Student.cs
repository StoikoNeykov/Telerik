namespace StudentsAndWorkers.Models
{
    using Interfaces;

    /// <summary>
    /// Base + grade 
    /// </summary>
    public class Student : Human, IHuman
    {
        private int grade; 

        public Student(string firstName, string lastName,int grade) 
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }
    }
}
