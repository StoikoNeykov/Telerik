namespace StudentsAndCourses.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Common;

    public class Course : ICourse
    {
        private ICollection<IStudent> studentsList;
        private string courseName;

        public Course(string courseName)
        {
            this.studentsList = new List<IStudent>();
            this.CourseName = courseName;
        }

        public IEnumerable<IStudent> StudentsList
        {
            get
            {
                return new List<IStudent>(this.studentsList);
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be null or empty!");
                }

                this.courseName = value;
            }
        }

        public void AddStudent(IStudent student)
        {
            Validator.NullCheck(student, "Student");

            if (this.studentsList.Count >=GlobalConstants.MaxStudentsInCourse)
            {
                throw new InvalidOperationException("Course is already full!");
            }

            if (Validator.IsPartOfCollection(this.studentsList, student))
            {
                throw new InvalidOperationException($"{student} is already added in {this}");
            }

            this.studentsList.Add(student);
        }

        public void RemoveStudent(IStudent student)
        {
            Validator.NullCheck(student, "Student");

            if (Validator.IsPartOfCollection(this.studentsList, student))
            {
                this.studentsList.Remove(student);
            }
            else
            {
                throw new InvalidOperationException($"{student} do not exsist in {this}");
            }
        }

        public override string ToString()
        {
            return this.CourseName;
        }
    }
}
