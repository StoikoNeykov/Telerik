namespace StudentsAndCourses.Contracts
{
    using System.Collections.Generic;

    public interface ISchool
    {
        string SchoolName { get; }

        ICollection<IStudent> StudentList { get; }

        ICollection<ICourse> CoursesList { get; }

        int GenerateStudentId();

        void AddStudent(IStudent student);

        void RemoveStudent(IStudent student);

        void AddCourse(ICourse course);

        void RemoveCourse(ICourse course);
    }
}
