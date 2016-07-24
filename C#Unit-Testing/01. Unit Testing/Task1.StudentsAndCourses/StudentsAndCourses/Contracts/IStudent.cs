namespace StudentsAndCourses.Contracts
{
    using System.Collections.Generic;

    public interface IStudent
    {
        int Id { get; }
        string Name { get; }

        IEnumerable<ICourse> Courses { get; }

        void JoinCourse(ICourse course);

        void LeaveCourse(ICourse course);
    }
}
