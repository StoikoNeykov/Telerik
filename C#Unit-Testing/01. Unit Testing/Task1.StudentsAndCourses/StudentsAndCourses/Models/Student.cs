namespace StudentsAndCourses.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Common;

    /// <summary>
    /// Student is made to be part of school system not to represent persons who changing schools
    /// </summary>
    public class Student : IStudent
    {
        private int id;
        private string name;
        private ICollection<ICourse> courses;

        // I know it looks weird BUT 1 person is student ONLY if part of some school
        // curent instance of Student working with only 1 school so if he/she leave it there 
        // is no more courseslist, id and he/she is not student anymore and object is useless in this context
        // ofc the idea is to use mocking to pass that school - practice is everything
        public Student(string name, ISchool school)
        {
            Validator.NullCheck(school, "School");

            this.Id = school.GenerateStudentId();
            this.courses = new List<ICourse>();
            this.Name = name;
            school.AddStudent(this);
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
                    throw new ArgumentException("Student name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("Id should be in range 10000-99999");
                }

                this.id = value;
            }
        }

        public IEnumerable<ICourse> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void JoinCourse(ICourse course)
        {
            Validator.NullCheck(course, "Course");

            if (Validator.IsPartOfCollection(this.courses, course))
            {
                throw new InvalidOperationException($"{this} is already part of {course}");
            }

            course.AddStudent(this);
            this.courses.Add(course);
        }

        public void LeaveCourse(ICourse course)
        {
            Validator.NullCheck(course, "Course");

            if (Validator.IsPartOfCollection(this.courses, course))
            {
                course.RemoveStudent(this);
                this.courses.Remove(course);
            }
            else
            {
                throw new InvalidOperationException($"{course} is not added in {this} courses!");
            }

        }

        public override string ToString()
        {
            return $"{this.name} ({this.id})";
        }
    }
}
