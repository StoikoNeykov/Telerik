namespace StudentsAndCourses.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    using Common;
    using Contracts;
    using Models;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseCreate_WithNullName_ShouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Course(null));
        }

        [TestMethod]
        public void CourseCreate_WithStringEmptyName_ShouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Course(string.Empty));
        }

        [TestMethod]
        public void CourseCreate_ShouldProperlySaveTheName()
        {
            var expected = "courseName";

            var course = new Course(expected);

            Assert.AreEqual(expected, course.CourseName);
        }

        [TestMethod]
        public void CourseConstructor_ShouldInstanceCollectionOfStudents()
        {
            var course = new Course("name");

            Assert.IsInstanceOfType(course.StudentsList, typeof(ICollection<IStudent>));
        }

        [TestMethod]
        public void CourseAddStudent_ShouldAddTheStudentInStudentList()
        {
            var student = Mock.Create<IStudent>();

            var course = new Course("name");

            bool isFound = false;

            course.AddStudent(student);

            foreach (var st in course.StudentsList)
            {
                if (st.Equals(student))
                {
                    isFound = true;
                }
            }

            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void CourseAddStudent_WithNull_ShouldThrowAnException()
        {
            var course = new Course("string");

            Assert.ThrowsException<ArgumentNullException>(() => course.AddStudent(null));
        }

        [TestMethod]
        public void CourseAddStudent_ShouldThrowAnExcception_IfTryToAddSameStudentManyTimes()
        {
            var student = Mock.Create<IStudent>();

            var course = new Course("TheNameDoesntMetter");
            course.AddStudent(student);

            Assert.ThrowsException<InvalidOperationException>(() => course.AddStudent(student));
        }

        [TestMethod]
        public void CourseAddStudent_ShouldThrowAnException_IfTryToAddMoreStudentsThenMaxPosible()
        {
            var course = new Course("name");

            for (int i = 0; i < GlobalConstants.MaxStudentsInCourse; i++)
            {
                var student = Mock.Create<IStudent>();
                course.AddStudent(student);
            }

            var stud = Mock.Create<IStudent>();

            Assert.ThrowsException<InvalidOperationException>(() => course.AddStudent(stud));

        }

        [TestMethod]
        public void CourseRemoveStudent_ShouldThrowAnException_IfStudentIsNull()
        {
            var course = new Course("name");

            Assert.ThrowsException<ArgumentNullException>(() => course.RemoveStudent(null));
        }

        [TestMethod]
        public void CourseRemoveStudent_ShouldRemoveStudentFromStudentListProperly()
        {
            var student = Mock.Create<IStudent>();
            var isFound = false;

            var course = new Course("string");

            course.AddStudent(student);

            course.RemoveStudent(student);

            foreach (var st in course.StudentsList)
            {
                if (st.Equals(student))
                {
                    isFound = true;
                }
            }

            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void CourseRemoveStudent_ShouldThrowAnException_IfRemovedStudentIsNOTinStudentsList()
        {
            var student = Mock.Create<IStudent>();

            var course = new Course("theName");

            Assert.ThrowsException<InvalidOperationException>(() => course.RemoveStudent(student));
        }

        [TestMethod]
        public void CourseToString_ShouldReturnCourseName()
        {
            var name = "thatName";

            var course = new Course(name);

            Assert.AreEqual(name, course.ToString());
        }


    }
}
