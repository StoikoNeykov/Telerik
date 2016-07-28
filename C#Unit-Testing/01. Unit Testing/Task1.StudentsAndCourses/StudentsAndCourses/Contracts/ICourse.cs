namespace StudentsAndCourses.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string CourseName { get; }

        // ICollection have Count
        IEnumerable<IStudent> StudentsList { get; }

        void AddStudent(IStudent student);
        void RemoveStudent(IStudent student);
    }
}
