namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolClasses.Interfaces;

    /// <summary>
    /// Represent school classes. Holds list of students and list of teachers for every instance. 
    /// ClassIdent is something like a name
    /// </summary>
    public class ClassOfStudents : ICommentable
    {
        private string classIdent;

        private List<Student> students;

        private List<Teacher> teachers;

        private string comment;

        public ClassOfStudents(string classIdent)
        {
            this.ClassIdent = classIdent;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
            private set
            {
                this.students = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            }
            private set
            {
                this.teachers = value;
            }
        }

        public string ClassIdent
        {
            get
            {
                return this.classIdent;
            }
            private set
            {
                this.classIdent = value;
            }
        }

        public string Comment
        {
            get
            {
                if (string.IsNullOrEmpty(this.Comment))
                {
                    return "There is not comments added for this class still!";
                }
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Contains(student))
            {
                throw new ArgumentException("This student is already in this class");
            }
            if (!string.IsNullOrEmpty(student.ClassIdent))
            {
                throw new ArgumentException("This student is already part of other class");
            }
            this.students.Add(student);
            student.ClassIdent = this.classIdent;
            student.NumberInClass = this.students.IndexOf(student);
        }

        public bool RemoveStudent(Student student)
        {
            if (this.Students.Count == 0)
            {
                return false;
            }

            foreach (var stud in this.students)
            {
                if (stud.Equals(student))
                {
                    this.students.Remove(stud);
                    stud.NumberInClass = 0;
                    stud.ClassIdent = null;

                    //change unique number in class for all others
                    foreach (var studInClass in this.students)
                    {
                        studInClass.NumberInClass = this.students.IndexOf(studInClass);
                    }

                    return true;
                }
            }

            return false;
        }

        public void AddTeacher(Teacher teacher)
        {
            if (this.Teachers.Count != 0)
            {
                foreach (var tchr in this.Teachers)
                {
                    if (tchr.Equals(teacher))
                    {
                        throw new ArgumentException("This teacher is already added in this class!");
                    }
                }
            }

            this.Teachers.Add(teacher);
        }

        public bool RemoveTeacher(Teacher teacher)
        {
            if (this.Teachers.Count == 0)
            {
                return false;
            }

            foreach (var tchr in this.Teachers)
            {
                if (tchr.Equals(teacher))
                {
                    this.Teachers.Remove(tchr);
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.ClassIdent;
        }

        public string FullString()
        {
            return string.Format("{0}:{1}Teachers:{1}{2}{1}Students:{1}{3}",
                this.ClassIdent,
                Environment.NewLine,
                string.Join(Environment.NewLine, this.Teachers),
                string.Join(Environment.NewLine, this.Students));
        }
    }
}
