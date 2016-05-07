using System;
using System.Linq;

class MaximalSum
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
        var matrix = new int[lines][];
        for (int i = 0; i < lines; i++)
        {
            matrix[i] = new int[members];
        }
        for (int i = 0; i < lines; i++)
        {
            text = null;
            text = Console.ReadLine();
            matrix[i] = text
            .Split(' ')
            .Select(z => Convert.ToInt32(z))
            .ToArray();
        }
        int max = int.MinValue;
        for (int i = 0; i < lines - 2; i++) //-2 coz need 3x3 but can be changed if need 
        {
            for (int j = 0; j < members - 2; j++) //-2 can be changed too if need 
            {
                int curentSum = GetSum(matrix, i, j);
                if (curentSum>max)
                {
                    max = curentSum;
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
    //rows and cols now are 3x3 but can be changed if need diferent check
    static int GetSum(int[][] matrix, int startRow, int startCol, int rows = 3, int cols = 3)
    {
        int Sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Sum += matrix[startRow + i][startCol + j];
            }
        }
        return Sum;
    }
}

