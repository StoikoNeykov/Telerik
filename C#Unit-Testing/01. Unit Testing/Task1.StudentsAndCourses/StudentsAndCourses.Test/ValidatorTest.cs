namespace StudentsAndCourses.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Common;

    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void ValidatorIsNull_WithNulls_ShouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Validator.ThrowIfNull(null, null));
        }

        [TestMethod]
        public void ValidatorIsNull_WithNullObjectAndString_shouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Validator.ThrowIfNull(null, "string"));
        }

        [TestMethod]
        public void ValidatorIsNull_WithNullObjectAndStringEmpty_shouldThrowAnException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Validator.ThrowIfNull(null, string.Empty));
        }

        [TestMethod]
        public void ValidatorIsNull_withObjAndString_ShouldNotThrows()
        {
            try
            {
                Validator.ThrowIfNull(new Object(), "string");
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
                Validator.ThrowIfNull(new Object(), string.Empty);
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
                Validator.ThrowIfNull(new Object(), null);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got {ex.Message}");
            }
        }

       
    }
}
