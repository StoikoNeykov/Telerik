using System;
using System.Linq;
using System.Numerics;

class BitShiftMatrix
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        text = Console.ReadLine();
        //every cell is pow(2, col + rows - curentRow) so no need to calc whole matrix - only check for visited
        var matrix = new bool[rows, cols];
        int curentRow = rows - 1;
        int curentCol = 0;
        var moves = text
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        BigInteger result = 0;
        foreach (var move in moves)
        {
            result += MoveMaker(matrix, rows, cols, move, ref curentRow, ref curentCol);
        }

        Console.WriteLine(result);
    }

    static BigInteger MoveMaker(bool[,] matrix, int rows, int cols, int move, ref int curentRow, ref int curentCol)
    {
        int coef = Math.Max(rows, cols);
        int targetCol = move % coef;
        int targetRow = move / coef;
        BigInteger sum = 0;
        sum += ColMover(matrix, rows, ref curentRow, ref curentCol, targetCol);
        sum += RowMover(matrix, rows, ref curentRow, ref curentCol, targetRow);
        return sum;
    }
    static BigInteger ColMover(bool[,] matrix, int rows, ref int curentRow, ref int curentCol, int targetCol)
    {
        BigInteger sum = 0;
        for (int i = Math.Min(curentCol, targetCol); i <= Math.Max(curentCol, targetCol); i++)
        {
            if (matrix[curentRow, i] == false)  //not visited
            {
                sum += GetCellValue(matrix, rows, curentRow, i);

            }
        }
        curentCol = targetCol;
        return sum;

    }
    static BigInteger RowMover(bool[,] matrix, int rows,ref int curentRow,ref int curentCol, int targetRow)
    {
        BigInteger sum = 0;
        for (int i = Math.Min(curentRow, targetRow); i <= Math.Max(curentRow, targetRow); i++)
        {
            if (matrix[i, curentCol] == false)  //not visited
            {
                sum += GetCellValue(matrix, rows, i, curentCol);
            }
        }
        curentRow = targetRow;
        return sum;
    }

    static BigInteger GetCellValue(bool[,] matrix, int rows, int row, int col)
    {
        BigInteger result = BigInteger.Pow(2, rows - 1 - row + col);
        matrix[row, col] = true;
        return result;
    }
}

