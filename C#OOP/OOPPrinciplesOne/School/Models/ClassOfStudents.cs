namespace School.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class ClassOfStudents : SchoolItem, ICommentable
    {
        private List<Teacher> teachers;

        private List<Student> students;

        public ClassOfStudents(string name)
            : base(name)
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
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

        public void AddTeacher(Teacher teacher)
        {
            if (this.teachers.Count > 0)
            {
                foreach (var tchr in this.teachers)
                {
                    if (tchr.Equals(teacher))
                    {
                        throw new ArgumentException("Already added!");
                    }
                }
            }

            this.teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            if (student.ClassId != 0)
            {
                throw new ArgumentException("Student already part of other class!");
            }

            if (this.students.Count > 0)
            {
                foreach (var stud in this.students)
                {
                    if (stud.Equals(student))
                    {
                        throw new ArgumentException("Already added!");
                    }
                }
            }

            this.students.Add(student);
            student.ClassId = this.students.Count - 1;
        }

        public bool RemoveTeacher(Teacher teacher)
        {
            if (this.teachers.Count > 0)
            {
                foreach (var tchr in this.teachers)
                {
                    if (tchr.Equals(teacher))
                    {
                        this.teachers.Remove(tchr);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool RemoveStudent(Student student)
        {
            if (this.students.Count > 0)
            {
                foreach (var stud in this.students)
                {
                    if (stud.Equals(student))
                    {
                        this.students.Remove(stud);
                        foreach (var other in this.students)
                        {
                            other.ClassId = this.students.IndexOf(other);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.Ident;
        }
    }
}
