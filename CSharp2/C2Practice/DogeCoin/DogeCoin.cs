using System;
using System.Linq;

class DogeCoin
{
    static void Main()
    {
        int[] input = ReadNumbers();
        int rows = input[0];
        int cols = input[1];

        var matrix = new long[rows, cols];

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            input = ReadNumbers();
            matrix[input[0], input[1]]++;
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                CalcCurentMax(matrix, i, j);
            }
        }
        Console.WriteLine(matrix[rows - 1, cols - 1]);
    }

    private static int[] ReadNumbers()
    {
        var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        return input;
    }

    private static void CalcCurentMax(long[,] matrix, int row, int col)
    {
        long bigger = 0;
        if (row != 0)
        {
            bigger = matrix[row - 1, col];
        }
        if (col != 0)
        {
            if (matrix[row, col - 1] > bigger)
            {
                bigger = matrix[row, col - 1];
            }
        }
        matrix[row, col] += bigger;
    }
}
