using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {

        public OffsiteCourse(string courseName)
            : base(courseName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            var baseToString = base.ToString();
            var result = baseToString.Substring(0, baseToString.Length - 2);

            if (this.Town != null)
            {
                result += "; Town = ";
                result += this.Town;
            }

            result += " }";

            return result.ToString();
        }
    }
}
