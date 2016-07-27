namespace StudentsAndCourses.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Common;

    public class School : ISchool
    {
        private string schoolName;
        private ICollection<ICourse> coursesList;
        private ICollection<IStudent> studentList;

        public School(string schoolName)
        {
            this.coursesList = new List<ICourse>();
            this.studentList = new List<IStudent>();
            this.SchoolName = schoolName;
        }

        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("School name cannot be null or empty!");
                }

                this.schoolName = value;
            }
        }

        public IEnumerable<ICourse> CoursesList
        {
            get
            {
                return new List<ICourse>(this.coursesList);
            }
        }

        public IEnumerable<IStudent> StudentList
        {
            get
            {
                return this.studentList;
            }
        }

        public void AddCourse(ICourse course)
        {
            Validator.NullCheck(course, "Course");

            if (Validator.IsPartOfCollection(this.coursesList, course))
            {
                throw new InvalidOperationException($"{course} is already added in {this}");
            }
            else
            {
                this.coursesList.Add(course);
            }
        }

        public void RemoveCourse(ICourse course)
        {
            Validator.NullCheck(course, "Course");

            if (Validator.IsPartOfCollection(this.coursesList, course))
            {
                this.coursesList.Remove(course);
            }
            else
            {
                throw new InvalidOperationException($"{course} is not added in {this}");
            }
        }

        public void AddStudent(IStudent student)
        {
            Validator.NullCheck(student, "Student");

            if (Validator.IsPartOfCollection(this.studentList, student))
            {
                throw new InvalidOperationException($"{student} is already added in {this}");
            }
            else
            {
                this.studentList.Add(student);
            }
        }

        public void RemoveStudent(IStudent student)
        {
            Validator.NullCheck(student, "Student");

            if (Validator.IsPartOfCollection(this.studentList, student))
            {
                this.studentList.Remove(student);
            }
            else
            {
                throw new InvalidOperationException($"{student} is not part of {this}");
            }
        }

        public int GenerateStudentId()
        {
            if (this.studentList.Count >= GlobalConstants.MaxStudents)
            {
                throw new InvalidOperationException($"{this} is overpopulated!");
            }

            var id = GlobalConstants.StudentIdStartsFrom + this.studentList.Count;

            return id;
        }

        public override string ToString()
        {
            return this.schoolName;
        }
    }
}
