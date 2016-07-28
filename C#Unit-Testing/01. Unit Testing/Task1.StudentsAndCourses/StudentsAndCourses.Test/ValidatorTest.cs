namespace StudentsAndCourses.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Common;

    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void ValidatorIsNull_WithNulls_ShouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Validator.NullCheck(null, null));
        }

        [TestMethod]
        public void ValidatorIsNull_WithNullObjectAndString_shouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Validator.NullCheck(null, "string"));
        }

        [TestMethod]
        public void ValidatorIsNull_WithNullObjectAndStringEmpty_shouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Validator.NullCheck(null, string.Empty));
        }

        [TestMethod]
        public void ValidatorIsNull_withObjAndString_ShouldNotThrows()
        {
            try
            {
                Validator.NullCheck(new Object(), "string");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got {ex.Message}");
            }
        }

        [TestMethod]
        public void ValidatorIsNull_withObjAndStringEmpty_ShouldNotThrows()
        {
            try
            {
                Validator.NullCheck(new Object(), string.Empty);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got {ex.Message}");
            }
        }

        [TestMethod]
        public void ValidatorIsNull_withObjAndStringNull_ShouldNotThrows()
        {
            try
            {
                Validator.NullCheck(new Object(), null);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got {ex.Message}");
            }
        }

        [TestMethod]
        public void ValidatorIsPartOF_ShouldFindItemInCollection()
        {
            var collection = new List<int> { -1, 2, -4, 303, 6, 0, 2, 5 };
            var needed = collection[6];

            Assert.IsTrue(Validator.IsPartOfCollection(collection, needed));
        }

        [TestMethod]
        public void ValidatorIsPartOf_IfItemIsNotPartOfCollection_ShouldReturnFalse()
        {
            var collection = new List<int> { 1, 2, 4, 103, -6, 9, 2, 1045 };
            var needed = 0;

            Assert.IsFalse(Validator.IsPartOfCollection(collection, needed));
        }

        [TestMethod]
        public void ValidatorIsPartOf_WithNullCollection_ShouldThrowAnException()
        {
            var needed = "string";

            Assert.ThrowsException<ArgumentNullException>(() => Validator.IsPartOfCollection(null, needed));
        }

        public void ValidatorIsPartOf_WithCollectionAndNullObj_ShouldThrowAnException()
        {
            var collection = new List<string> { "pesho", "gosho", "ivan", "stoqn", "stamat" };

            Assert.ThrowsException<ArgumentNullException>(() => Validator.IsPartOfCollection(collection, null));
        }
    }
}
