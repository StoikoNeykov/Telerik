using System;
using System.Linq;

//NOT 100/100 coz check in 1 direction ONLY 
// for 100/100check MegaChecker

class SequenceInMatrix
{
    static void Main()
    {
        string text = Console.ReadLine();
        var result = text
            .Split(' ')
            .Select(z => Convert.ToInt32(z))
            .ToArray();
        int lines = result[0];
        int members = result[1];
        var matrix = new string[lines][];
        for (int i = 0; i < lines; i++)
        {
            matrix[i] = new string[members];
        }
        for (int i = 0; i < lines; i++)
        {
            text = null;
            text = Console.ReadLine();
            matrix[i] = text
            .Split(' ')
            .Select(z => z)
            .ToArray();
        }
        int max = 0;
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < members; j++)
            {
                int curent = CheckRow(matrix, i, j, 1);
                if (curent > max)
                {
                    max = curent;
                }
                curent = CheckCol(matrix, i, j, 1);
                if (curent > max)
                {
                    max = curent;
                }
                curent = CheckDiagonal(matrix, i, j, 1);
                if (curent > max)
                {
                    max = curent;
                }
            }
        }
        Console.WriteLine(max);
        //for (int i = 0; i < lines; i++)
        //{
        //    for (int j = 0; j < members; j++)
        //    {
        //        Console.Write(matrix[i][j]);
        //        if (j != members - 1)
        //        {
        //            Console.Write(' ');
        //        }
        //    }
        //    Console.WriteLine();
        //}
    }
    static int CheckRow(string[][] matrix, int row, int col, int curent)
    {
        if ((col < matrix[row].Length - 1) && (matrix[row][col + 1] == matrix[row][col]))
        {
            curent++;
            curent = CheckRow(matrix, row, col + 1, curent);
        }
        return curent;
    }

    static int CheckCol(string[][] matrix, int row, int col, int curent)
    {
        if ((row < matrix.Length - 1) && (matrix[row + 1][col] == matrix[row][col]))
        {
            curent++;
            curent = CheckCol(matrix, row + 1, col, curent);
        }
        return curent;
    }

    static int CheckDiagonal(string[][] matrix, int row, int col, int curent)
    {
        if ((col < matrix[row].Length - 1) && (row < matrix.Length - 1) && (matrix[row + 1][col + 1] == matrix[row][col]))
        {
            curent++;
            curent = CheckDiagonal(matrix, row + 1, col + 1, curent);
        }
        return curent;
    }
}

