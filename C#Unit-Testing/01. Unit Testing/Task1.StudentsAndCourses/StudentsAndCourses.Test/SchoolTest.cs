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
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructor_ShouldMakeInstanceOf_CollectionOfCourses()
        {
            var school = new School("some name");

            Assert.IsInstanceOfType(school.CoursesList, typeof(ICollection<ICourse>));
        }

        [TestMethod]
        public void SchoolConstructor_ShouldMakeInstanceOf_COllectionOfStudents()
        {
            var school = new School("some another name");

            Assert.IsInstanceOfType(school.StudentList, typeof(ICollection<IStudent>));
        }

        [TestMethod]
        public void School_WithNameNull_ShouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentException>(() => new School(null));
        }

        [TestMethod]
        public void School_WithNameStringEmpty_ShoulThrowAnException()
        {
            Assert.ThrowsException<ArgumentException>(() => new School(string.Empty));
        }

        [TestMethod]
        public void School_ShouldProperlySetName()
        {
            var expected = "some string that have to me name";

            var school = new School(expected);

            Assert.AreEqual(expected, school.SchoolName);
        }

        [TestMethod]
        public void SchoolAddStudent_WithNullStudent_shouldThrowAnException()
        {
            var school = new School("rare school name");

            Assert.ThrowsException<ArgumentNullException>(() => school.AddStudent(null));
        }

        [TestMethod]
        public void SchoolAddStudent_ShouldAddStudentproperly()
        {
            var student = Mock.Create<IStudent>();

            var school = new School("last school On the earth (not capitalized)");

            school.AddStudent(student);

            bool isFound = false;

            foreach (var st in school.StudentList)
            {
                if (student.Equals(student))
                {
                    isFound = true;
                }
            }

            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void SchoolAddStudent_shouldThrowAnException_IfTryToAddSameStudentManyTimes()
        {
            var student = Mock.Create<IStudent>();

            var school = new School("theNameIsImportant");

            school.AddStudent(student);

            Assert.ThrowsException<InvalidOperationException>(() => school.AddStudent(student));
        }

        [TestMethod]
        public void SchoolAddCourse_withNull_shouldThrowAnException()
        {
            var school = new School("string");

            Assert.ThrowsException<ArgumentNullException>(() => school.AddCourse(null));
        }

        [TestMethod]
        public void SchoolAddCourse_ShouldAddCourseProperly()
        {
            var course = Mock.Create<ICourse>();
            bool isfound = false;

            var school = new School("school15");

            school.AddCourse(course);

            foreach (var c in school.CoursesList)
            {
                if (c.Equals(course))
                {
                    isfound = true;
                }
            }

            Assert.IsTrue(isfound);
        }

        [TestMethod]
        public void SchoolAddCourse_shouldThrowAnException_IfTryToAddSameCoursemanyTimes()
        {
            var course = Mock.Create<ICourse>();

            var school = new School("string");

            school.AddCourse(course);

            Assert.ThrowsException<InvalidOperationException>(() => school.AddCourse(course));
        }

        [TestMethod]
        public void SchoolRemoveStudent_ShouldThrowAnException_IfStudentIsNull()
        {
            var school = new School("name");

            Assert.ThrowsException<ArgumentNullException>(() => school.RemoveCourse(null));
        }

        [TestMethod]
        public void SchoolRemoveCourse_ShouldThrowAnException_IfCourseIsNull()
        {
            var school = new School("name");

            Assert.ThrowsException<ArgumentNullException>(() => school.AddCourse(null));
        }

        [TestMethod]
        public void SchoolRemoveStudent_ShouldProperlyRemoveStudent()
        {
            var student = Mock.Create<IStudent>();
            bool isFound = false;

            var school = new School("15-th school for superpowers");
            school.AddStudent(student);

            school.RemoveStudent(student);

            foreach (var st in school.StudentList)
            {
                if (st.Equals(student))
                {
                    isFound = true;
                }
            }

            Assert.IsFalse(isFound);


        }

        [TestMethod]
        public void SchoolRemoveStudent_ShouldThrowAnException_IfStudentIsNotAdded ()
        {
            var student = Mock.Create<IStudent>();

            var school = new School("name");

            Assert.ThrowsException<InvalidOperationException>(() => school.RemoveStudent(student));
        }

        [TestMethod]
        public void SchoolRemoveCourse_ShouldThrowAnException_IfCourseIsNotAdded()
        {
            var course = Mock.Create<ICourse>();

            var school = new School("the name");

            Assert.ThrowsException<InvalidOperationException>(() => school.RemoveCourse(course));
        }

        [TestMethod]
        public void SchoolRemoveCourse_shouldProperlyRemoveCourseFromCoursesList()
        {
            var course = Mock.Create<ICourse>();
            bool isFound = false;

            var school = new School("some name");
            school.AddCourse(course);

            school.RemoveCourse(course);

            foreach (var c in school.CoursesList)
            {
                if (c.Equals(course))
                {
                    isFound = true;
                }
            }

            Assert.IsFalse(isFound);
        }
    }
}
