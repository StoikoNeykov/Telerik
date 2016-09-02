using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public LocalCourse(string courseName):
            base(courseName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            :base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var baseToString = base.ToString();
            var result = baseToString.Substring(0, baseToString.Length - 2);

            if (this.Lab != null)
            {
                result += "; Lab = ";
                result += this.Lab;
            }

            result += " }";

            return result.ToString();
        }
    }
}
