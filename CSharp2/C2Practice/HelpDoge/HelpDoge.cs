using System;
using System.Linq;
using System.Numerics;

class HelpDoge
{
    static void Main()
    {
        var dimentions = ReadCoord();
        int rows = dimentions[0];
        int cols = dimentions[1];
        var matrix = new BigInteger[rows, cols];
        matrix[0, 0] = 1;
        //enemies will be negative

        dimentions = ReadCoord();
        int foodRow = dimentions[0];
        int foodCol = dimentions[1];
        if (foodRow > rows - 1 || foodRow < 0 || foodCol > cols - 1 || foodCol < 0)
        {
            //food out of matrix
            Console.WriteLine("0");
            return;
        }

        int enemies = int.Parse(Console.ReadLine());
        for (int i = 0; i < enemies; i++)
        {
            dimentions = ReadCoord();
            if (dimentions[0] > 0 || dimentions[0] < rows || dimentions[1] > 0 || dimentions[1] < cols)
            {
                matrix[dimentions[0], dimentions[1]] = -1;

                //else enemie out of matrix
            }
        }
        for (int i = 0; i <= foodRow; i++)
        {
            for (int j = 0; j <= foodCol; j++)
            {
                PosiblePathsCalc(matrix, foodRow, foodCol, i, j);
            }
        }
        Console.WriteLine(matrix[foodRow, foodCol]);
    }

    private static void PosiblePathsCalc(BigInteger[,] matrix, int foodRow, int foodCol, int row, int col)
    {
        if (matrix[row, col] != 0)
        {
            return;
        }
        if (row != 0 && matrix[row - 1, col] > 0)
        {
            matrix[row, col] += matrix[row - 1, col];
        }
        if (col != 0 && matrix[row, col - 1] > 0)
        {
            matrix[row, col] += matrix[row, col - 1];
        }
    }

    static int[] ReadCoord()
    {
        var dimentions = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        return dimentions;
    }
}

