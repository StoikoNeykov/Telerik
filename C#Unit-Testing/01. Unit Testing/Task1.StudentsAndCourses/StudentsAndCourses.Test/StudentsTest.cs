namespace StudentsAndCourses.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

            Assert.ThrowsException<ArgumentException>(() => new Student(null, school));
        }

        [TestMethod]
        public void StudentCreate_WithStringEmptyName_ShouldThrowAnException()
        {
            var school = Mock.Create<ISchool>();

            Assert.ThrowsException<ArgumentException>(() => new Student(string.Empty, school));
        }

        [TestMethod]
        public void StudentCreate_withNullSchool_ShouldThrowAmException()
        {
            var name = "Name";

            Assert.ThrowsException<ArgumentNullException>(() => new Student(name, null));
        }

        [TestMethod]
        public void Student_Constructor_ShouldCreateInstanceOfCoursesCollection()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);

            var student = new Student("name", school);

            Assert.IsInstanceOfType(student.Courses, typeof(ICollection<ICourse>));
        }

        [TestMethod]
        public void Student_ShouldProperlySaveTheName()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);

            var expected = "pesho";

            var student = new Student(expected, school);

            Assert.AreEqual(expected, student.Name);
        }

        [TestMethod]
        public void Student_ShouldSaveProperlyIdGotFromSchoolGetIdMethod()
        {
            var expected = 50000;

            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(expected);

            var student = new Student("name", school);

            Assert.AreEqual(expected, student.Id);
        }

        [TestMethod]
        public void StudentCreate_IdOutOfRange_ShouldThrowAnException()
        {
            var expected = -7;

            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(expected);

            Assert.ThrowsException<ArgumentException>(() => new Student("name", school));
        }

        [TestMethod]
        public void StudentJoinCourse_ShouldIncreaseCoursesCount()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);
            var course = Mock.Create<ICourse>();
            var course2 = Mock.Create<ICourse>();

            var student = new Student("name", school);

            student.JoinCourse(course);
            student.JoinCourse(course2);

            //Count with Linq coz Courses is IEnumerable 
            Assert.AreEqual(2, student.Courses.Count());
        }

        [TestMethod]
        public void StudentJoinCourse_ShouldThrowAnException_WhenTryToJoinSameCourseMoreThenOnce()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);
            var course = Mock.Create<ICourse>();

            var student = new Student("name", school);

            student.JoinCourse(course);

            Assert.ThrowsException<InvalidOperationException>(() => student.JoinCourse(course));
        }

        [TestMethod]
        public void StudentJoinCourse_SHouldThrowAnExceptionWnenCourseIsNull()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);

            var student = new Student("name", school);

            Assert.ThrowsException<ArgumentNullException>(() => student.JoinCourse(null));
        }

        [TestMethod]
        public void StudentJoinCourse_ShouldProperlyAddTheCourseInTheCourses()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(34000);

            var course = Mock.Create<ICourse>();

            var student = new Student("gosho", school);
            student.JoinCourse(course);

            bool IsFound = false;

            foreach (var c in student.Courses)
            {
                if (course.Equals(c))
                {
                    IsFound = true;
                }
            }

            Assert.IsTrue(IsFound);
        }

        [TestMethod]
        public void StudentLeaveCourse_ShouldThrowAnException_WithNullCourse()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);

            var student = new Student("name", school);

            Assert.ThrowsException<ArgumentNullException>(() => student.LeaveCourse(null));
        }

        [TestMethod]
        public void StudentLeaveCourse_ShouldProperlyDecreaseCursesCount()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);

            var course = Mock.Create<ICourse>();

            var student = new Student("pesho", school);

            student.JoinCourse(course);
            student.LeaveCourse(course);

            Assert.AreEqual(0, student.Courses.Count());
        }

        [TestMethod]
        public void StudentLeaveCourse_ShouldThrowAnException_IfCourseIsNotJoined()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(56000);

            var course = Mock.Create<ICourse>();

            var student = new Student("pesho", school);

            Assert.ThrowsException<InvalidOperationException>(() => student.LeaveCourse(course));
        }

        [TestMethod]
        public void StudentLeaveCourse_ShouldRemoveTheCourseFromCourses()
        {
            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(12000);

            var course = Mock.Create<ICourse>();
            bool IsFound = false;

            var student = new Student("name", school);
            student.JoinCourse(course);

            student.LeaveCourse(course);

            foreach (var c in student.Courses)
            {
                if (c.Equals(course))
                {
                    IsFound = true;
                }
            }

            Assert.IsFalse(IsFound);
        }

        [TestMethod]
        public void StudentToString_ShouldReturnsNameAndIdInSpecificFormat()
        {
            var id = 12000;
            var name = "Stamat";

            var school = Mock.Create<ISchool>();
            Mock.Arrange(() => school.GenerateStudentId()).Returns(id);

            var student = new Student(name, school);

            Assert.AreEqual($"{name} ({id})", student.ToString());
        }

    }
}
