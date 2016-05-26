using System;
using System.Linq;


class Patterns
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var matrix = new int[size][];
        for (int i = 0; i < size; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        long max = 0;
        for (int i = 0; i < size - 2; i++)
        {
            for (int j = 0; j < size - 4; j++)
            {
                long curent = Checker(matrix, i, j);
                if (curent > max)
                {
                    max = curent;
                }
            }
        }
        if (max == 0)
        {
            Console.WriteLine("NO {0}", Diagonal(matrix));
        }
        else
        {
            Console.WriteLine("YES {0}", max);
        }

    }

    private static long Diagonal(int[][] matrix)
    {
        long result = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            result += matrix[i][i];
        }
        return result;
    }

    private static long Checker(int[][] matrix, int row, int col)
    {
        long result = 0;
        if (matrix[row][col] + 1 == matrix[row][col + 1] &&
                matrix[row][col + 1] + 1 == matrix[row][col + 2] &&
                matrix[row][col + 2] + 1 == matrix[row + 1][col + 2] &&
                matrix[row + 1][col + 2] + 1 == matrix[row + 2][col + 2] &&
                matrix[row + 2][col + 2] + 1 == matrix[row + 2][col + 3] &&
                matrix[row + 2][col + 3] + 1 == matrix[row + 2][col + 4])
        {
            result = matrix[row][col] * 7 + 21;
        }


        return result;
    }
}
