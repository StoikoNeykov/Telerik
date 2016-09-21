using System;
using GameFifteen.Enumerations;
using GameFifteen.Models;
using GameFifteen.Contracts;

namespace GameFifteen.Common
{
    public class Utils
    {
        private static readonly int[] RowChange = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] ColChange = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static ICoords GetNextCoords(ICoords coords, Direction direction)
        {
            var newRow = coords.Row + RowChange[(int)direction];
            var newCol = coords.Col + ColChange[(int)direction];
            return new Coords(newRow, newCol);
        }

        public static bool IsCoordsInMatrixRange(int[,] matrix, ICoords coords)
        {
            var isRowInRange = 0 <= coords.Row && coords.Row < matrix.GetLength(0);
            var isColInRange = 0 <= coords.Col && coords.Col < matrix.GetLength(1);

            return isRowInRange && isColInRange;
        }

        public static Direction GetNextDirection(Direction direction)
        {
            int directionCount = Enum.GetNames(typeof(Direction)).Length;

            if ((int)direction == directionCount - 1)
            {
                return (Direction)0;
            }
            else
            {
                return (Direction)((int)direction + 1);
            }
        }
    }
}
