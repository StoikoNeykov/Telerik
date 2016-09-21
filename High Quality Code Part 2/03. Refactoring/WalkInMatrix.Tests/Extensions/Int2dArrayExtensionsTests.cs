using System.Collections.Generic;
using GameFifteen.Common;
using GameFifteen.Extensions;
using NUnit.Framework;

namespace WalkInMatrix.Tests.Extensions
{
    [TestFixture]
    public class Int2dArrayExtensionsTests
    {
        [Test]
        public void FillTillGlitch_ShouldProperlyFIllMatrix()
        {
            var expected = new int[,]
            {
                {1, 19, 20, 21, 22, 23, 24},
                {18, 2, 33, 34, 35, 36, 25},
                {17, 0, 3, 32, 39, 37, 26},
                {16, 0, 0, 4, 31, 38, 27},
                {15, 0, 0, 0, 5, 30, 28},
                {14, 0, 0, 0, 0, 6, 29},
                {13, 12, 11, 10, 9, 8, 7}

            };

            var result = new int[7, 7];

            result.FillTillGlitch(1);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void FillAll_ShouldProperlyFillMatrix()
        {
            var expected = new int[,]
            {
                {1, 19, 20, 21, 22, 23, 24},
                {18, 2, 33, 34, 35, 36, 25},
                {17, 40, 3, 32, 39, 37, 26},
                {16, 48, 41, 4, 31, 38, 27},
                {15, 47, 49, 42, 5, 30, 28},
                {14, 46, 45, 44, 43, 6, 29},
                {13, 12, 11, 10, 9, 8, 7}
            };

            var result = new int[7, 7];

            result.FillAll();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetMax_ShouldProperlyReturn_MaxValue()
        {
            var matrix = new int[,]
            {
                {-10, -20, -3, -4, -1, -3},
                {-4, -4, -3, -2,- 1,- 3}
            };

            var expected = -1;

            var result = matrix.GetMax();

            Assert.AreEqual(expected, result);

        }
    }
}
