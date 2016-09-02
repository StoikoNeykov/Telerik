﻿using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {

        public Course(string courseName):
            this(courseName, null, new List<string>())
        {
        }

        public Course(string courseName, string teacherName)
            :this(courseName, teacherName, new List<string>())
        {
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(" }");
            return result.ToString();
        }
    }
}
