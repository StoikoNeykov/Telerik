using System;
using GameFifteen.Common;
using GameFifteen.Contracts;
using GameFifteen.Enumerations;
using NUnit.Framework;
using Telerik.JustMock;

namespace WalkInMatrix.Tests.Common
{
    [TestFixture]
    public class UtilsTests
    {
        [TestCase(Direction.DownRight, 1, 1)]
        [TestCase(Direction.Down, 1, 0)]
        [TestCase(Direction.DownLeft, 1, -1)]
        [TestCase(Direction.Left, 0, -1)]
        [TestCase(Direction.UpLeft, -1, -1)]
        [TestCase(Direction.Up, -1, 0)]
        [TestCase(Direction.UpRight, -1, 1)]
        [TestCase(Direction.Right, 0, 1)]
        public void GetNextCoords_ShouldProperlyReturn_NewCoords(Direction direction,
                                                                    int expectedRow,
                                                                    int expectedCol)
        {
            var mockedCoords = Mock.Create<ICoords>();
            Mock.Arrange(() => mockedCoords.Row).Returns(0);
            Mock.Arrange(() => mockedCoords.Col).Returns(0);

            var result = Utils.GetNextCoords(mockedCoords, direction);

            Assert.AreEqual(expectedRow, result.Row);
            Assert.AreEqual(expectedCol, result.Col);
        }

        [TestCase(3, 3, 5, 5)]
        [TestCase(1, 1, 18, 5)]
        [TestCase(5, 11, 6, 12)]
        public void IsCoordsInMatrixRange_ShouldReturnTrue_WhenCoordsAreInRange(int coordRow,
                                                                                    int coordsCol,
                                                                                    int matrixRows,
                                                                                    int matrixCols)
        {
            var mockedCoords = Mock.Create<ICoords>();
            Mock.Arrange(() => mockedCoords.Row).Returns(coordRow);
            Mock.Arrange(() => mockedCoords.Col).Returns(coordsCol);

            var matrix = new int[matrixRows, matrixCols];

            Assert.IsTrue(Utils.IsCoordsInMatrixRange(matrix, mockedCoords));
        }

        [TestCase(5, 5, 1, 1)]
        [TestCase(10, 1, 4, 4)]
        [TestCase(3, 10, 5, 5)]
        public void IsCoordsInMatrixRange_ShouldReturnFalse_WhenCoordsAreOutOfRange(int coordRow,
                                                                                        int coordsCol,
                                                                                        int matrixRows,
                                                                                        int matrixCols)
        {
            var mockedCoords = Mock.Create<ICoords>();
            Mock.Arrange(() => mockedCoords.Row).Returns(coordRow);
            Mock.Arrange(() => mockedCoords.Col).Returns(coordsCol);

            var matrix = new int[matrixRows, matrixCols];

            Assert.IsFalse(Utils.IsCoordsInMatrixRange(matrix, mockedCoords));
        }

        [TestCase(6)]
        [TestCase(7)]
        [TestCase(0)]
        [TestCase(3)]
        public void GetNextDirection_ShouldProperlyReturnNextDIrection(int directionAsInt)
        {
            var directionCount = Enum.GetNames(typeof(Direction)).Length;

            var expected = directionAsInt == directionCount - 1 ? (Direction)0 : (Direction)(directionAsInt + 1);

            var direction = Utils.GetNextDirection((Direction)directionAsInt);

            Assert.AreEqual(expected, direction);
        }
    }
}
