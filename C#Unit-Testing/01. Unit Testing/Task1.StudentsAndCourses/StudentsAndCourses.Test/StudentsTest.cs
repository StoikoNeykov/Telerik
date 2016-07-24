namespace StudentsAndCourses.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    using Contracts;
    using Models;

    [TestClass]
    public class StudentsTest
    {
        [TestMethod]
        public void StudentCreate_WIthNameNull_ShouldThrowAnException()
        {
            var school = Mock.Create<ISchool>();

            var student = new Student(null, school);
        }
    }
}
