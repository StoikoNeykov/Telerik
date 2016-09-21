using System;
using GameFifteen.Enumerations;
using GameFifteen.Models;
using GameFifteen.Common;
using GameFifteen.Contracts;

namespace GameFifteen.Extensions
{
    public static class Int2dArrayExtensions
    {
        private static readonly int DirectionsCount = Enum.GetNames(typeof(Direction)).Length;

        public static void FillTillGlitch(this int[,] matrix, int startsFrom)
        {
            var coords = matrix.GetStartingCoords();

            if (coords == null)
            {
                // matrix is full
                return;
            }

            var direction = Direction.DownRight;
            var directionChanges = 0;

            for (int i = startsFrom; i < matrix.GetLength(0) * matrix.GetLength(1) + startsFrom; i++)
            {
                matrix[coords.Row, coords.Col] = i;

                var newCoords = matrix.GetNextCellCoords(coords, direction);
                var isSameCoords = coords.Row == newCoords.Row && coords.Col == newCoords.Col;
                var isEmpty = matrix[newCoords.Row, newCoords.Col] == 0;

                if (isSameCoords || (!isEmpty))
                {
                    direction = Utils.GetNextDirection(direction);

                    directionChanges++;
                    if (directionChanges > DirectionsCount)
                    {
                        // checked all directions and cant continue
                        return;
                    }
                    else
                    {
                        i--;
                        continue;
                        // with the new direction
                    }
                }
                else
                {
                    coords = newCoords;
                    directionChanges = 0;
                }
            }
        }

        public static void FillAll(this int[,] matrix)
        {
            while (matrix.GetMax() < matrix.GetLength(0) * matrix.GetLength(1))
            {
                matrix.FillTillGlitch(matrix.GetMax() + 1);
            }
        }

        public static int GetMax(this int[,] matrix)
        {
            var max = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > max)
                    {
                        max = matrix[row, col];
                    }
                }
            }

            return max;
        }

        private static ICoords GetNextCellCoords(this int[,] matrix, ICoords coords, Direction direction)
        {
            if (!Utils.IsCoordsInMatrixRange(matrix, coords))
            {
                throw new ArgumentOutOfRangeException("Coords");
            }

            var newCoords = Utils.GetNextCoords(coords, direction);

            var isNewCoordsBetter = Utils.IsCoordsInMatrixRange(matrix, newCoords);
            return isNewCoordsBetter ? newCoords : coords;
        }

        private static ICoords GetStartingCoords(this int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Coords(row, col);
                    }
                }
            }

            return null;
        }

    }
}
