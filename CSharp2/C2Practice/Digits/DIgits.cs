using System;
using System.Linq;

// 96/100 but annoying as fck 

class Digits
{
    static void Main()
    {
        var size = int.Parse(Console.ReadLine());

        var matrix = new int[size][];

        for (int i = 0; i < size; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        long curentSum = 0;
        for (int i = size - 1; i > 3; i--)
        {
            for (int j = size - 1; j > 1; j--)
            {
                curentSum += CheckSeven(matrix, i, j);
                switch (matrix[i][j])
                {
                    case 1: curentSum += CheckOne(matrix, i, j); break;
                    case 2: curentSum += CheckTwo(matrix, i, j); break;
                    case 3: curentSum += CheckThree(matrix, i, j); break;
                    case 4: curentSum += CheckFour(matrix, i, j); break;
                    case 5: curentSum += CheckFive(matrix, i, j); break;
                    case 6: curentSum += CheckSix(matrix, i, j); break;
                    case 8: curentSum += CheckEight(matrix, i, j); break;
                    case 9: curentSum += CheckNine(matrix, i, j); break;
                    default: break; //0 -> if have patern 0 it add 0 anyway
                                    //7-> already checked ! 
                }
            }
        }
        Console.WriteLine(curentSum);
    }

    private static long CheckNine(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 9 || matrix[row][col - 2] != 9 || matrix[row - 1][col] != 9 ||
            matrix[row - 2][col] != 9 || matrix[row - 2][col - 1] != 9 || matrix[row - 3][col] != 9 ||
            matrix[row - 3][col - 2] != 9 || matrix[row - 4][col] != 9 || matrix[row - 4][col - 1] != 9 ||
            matrix[row - 4][col - 2] != 9)
        {
            return 0;
        }
        else
        {
            return 9;
        }
    }

    private static long CheckEight(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 8 || matrix[row][col - 2] != 8 || matrix[row - 1][col] != 8 ||
            matrix[row - 1][col - 2] != 8 || matrix[row - 2][col - 1] != 8 || matrix[row - 3][col] != 8 ||
            matrix[row - 3][col - 2] != 8 || matrix[row - 4][col] != 8 || matrix[row - 4][col - 1] != 8 ||
            matrix[row - 4][col - 2] != 8)
        {
            return 0;
        }
        else
        {
            return 8;
        }
    }

    private static long CheckSeven(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 7 || matrix[row - 1][col - 1] != 7 || matrix[row - 2][col - 1] != 7 ||
            matrix[row - 3][col] != 7 || matrix[row - 4][col] != 7 || matrix[row - 4][col - 1] != 7 ||
            matrix[row - 4][col - 2] != 7)
        {
            return 0;
        }
        else
        {
            return 7;
        }
    }

    private static long CheckSix(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 6 || matrix[row][col - 2] != 6 || matrix[row - 1][col] != 6 ||
            matrix[row - 1][col - 2] != 6 || matrix[row - 2][col] != 6 || matrix[row - 2][col - 1] != 6 ||
            matrix[row - 2][col - 2] != 6 || matrix[row - 3][col - 2] != 6 || matrix[row - 4][col] != 6 ||
            matrix[row - 4][col - 1] != 6 || matrix[row - 4][col - 2] != 6)
        {
            return 0;
        }
        else
        {
            return 6;
        }
    }

    private static long CheckFive(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 5 || matrix[row][col - 2] != 5 || matrix[row - 1][col] != 5 ||
            matrix[row - 2][col] != 5 || matrix[row - 4][col] != 5 || matrix[row - 2][col - 1] != 5 ||
            matrix[row - 4][col - 1] != 5 || matrix[row - 2][col - 2] != 5 || matrix[row - 3][col - 2] != 5 ||
            matrix[row - 4][col - 2] != 5)
        {
            return 0;
        }
        else
        {
            return 5;
        }
    }

    private static long CheckFour(int[][] matrix, int row, int col)
    {
        if (matrix[row - 1][col] != 4 || matrix[row - 2][col] != 4 || matrix[row - 3][col] != 4 ||
            matrix[row - 4][col] != 4 || matrix[row - 2][col - 1] != 4 || matrix[row - 2][col - 2] != 4 ||
            matrix[row - 3][col - 2] != 4 || matrix[row - 4][col - 2] != 4)
        {
            return 0;
        }
        else
        {
            return 4;
        }
    }

    private static long CheckThree(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 3 || matrix[row][col - 2] != 3 || matrix[row - 1][col] != 3 ||
            matrix[row - 2][col] != 3 || matrix[row - 2][col - 1] != 3 || matrix[row - 3][col] != 3 ||
            matrix[row - 4][col] != 3 || matrix[row - 4][col - 1] != 3 || matrix[row - 4][col - 2] != 3)
        {
            return 0;
        }
        else
        {
            return 3;
        }
    }

    private static long CheckTwo(int[][] matrix, int row, int col)
    {
        if (matrix[row][col - 1] != 2 || matrix[row][col - 2] != 2 || matrix[row - 1][col - 1] != 2 ||
            matrix[row - 2][col] != 2 || matrix[row - 3][col] != 2 || matrix[row - 4][col - 1] != 2 ||
            matrix[row - 3][col - 2] != 2)
        {
            return 0;
        }
        else
        {
            return 2;
        }
    }

    private static long CheckOne(int[][] matrix, int row, int col)
    {
        if (matrix[row - 1][col] != 1 || matrix[row - 2][col] != 1 || matrix[row - 3][col] != 1 ||
            matrix[row - 4][col] != 1 || matrix[row - 3][col - 1] != 1 || matrix[row - 2][col - 2] != 1)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}