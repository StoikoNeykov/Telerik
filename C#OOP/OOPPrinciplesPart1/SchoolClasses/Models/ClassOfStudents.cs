namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolClasses.Interfaces;

    public class ClassOfStudents : ICommentable
    {
        // something like name
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

        private ClassOfStudents(ClassOfStudents classForCopy)
        {
            this.ClassIdent = classForCopy.ClassIdent;
            this.Students = new List<Student>(classForCopy.Students);
            this.Teachers = new List<Teacher>(classForCopy.Teachers);
            this.Comment = classForCopy.Comment;
        }

        public List<Student> Students
        {
            get
            {
                var result = new List<Student>();
                if (students.Count > 0)
                {
                    foreach (var student in this.students)
                    {
                        result.Add(student.CopyStudent());
                    }
                }
                return result;
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
                var result = new List<Teacher>();
                if (Teachers.Count > 0)
                {
                    foreach (var teach in this.Teachers)
                    {
                        result.Add(teach.CopyTeacher());
                    }
                }
                return result;
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

        internal ClassOfStudents CopyClass()
        {
            return new ClassOfStudents(this);
        }

        public override bool Equals(object classOfStudents)
        {
            if (!(classOfStudents is ClassOfStudents))
            {
                return false;
            }

            var other = classOfStudents as ClassOfStudents;
            if (this.ClassIdent == other.classIdent
                && this.Comment == other.Comment
                && this.Students == other.Students
                && this.Teachers == other.Teachers)
            {
                return true;
            }

            return false;
        }
    }
}
