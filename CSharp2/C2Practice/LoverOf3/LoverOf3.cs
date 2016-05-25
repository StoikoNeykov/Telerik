using System;
using System.Linq;

class LoverOf3
{
    static void Main()
    {
        string text = Console.ReadLine();
        var dimentions = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var matrix = new bool[dimentions[0], dimentions[1]];
        int commands = int.Parse(Console.ReadLine());
        long sum = 0;
        int curentRow = 0;
        int curentCol = 0;
        for (int i = 0; i < commands; i++)
        {
            text = Console.ReadLine();
            var curentCommand = text
                .Split(' ');
            int moves = int.Parse(curentCommand[1]);
            sum += Terminator(matrix, dimentions, curentCommand, ref curentRow, ref curentCol, moves - 1);
        }
        sum *= 3;
        Console.WriteLine(sum);
    }
    static int Terminator(bool[,] matrix, int[] dimentions, string[] curentCommand, ref int curentRow, ref int curentCol, int moves)
    {
        int result = 0;
        if (!matrix[curentRow, curentCol])
        {
            matrix[curentRow, curentCol] = true;
            result += (curentCol + curentRow);
        }
        if (moves == 0)
        {
            return result;
        }
        // up right
        if ((curentCommand[0].Contains("U") && curentCommand[0].Contains("R")) &&
            (curentRow != dimentions[0] - 1 && curentCol != dimentions[1] - 1))
        {
            curentCol++;
            curentRow++;
        }
        // up left
        if ((curentCommand[0].Contains("U") && curentCommand[0].Contains("L")) &&
           (curentRow != dimentions[0] - 1 && curentCol != 0))
        {
            curentCol--;
            curentRow++;
        }
        //down right
        if ((curentCommand[0].Contains("D") && curentCommand[0].Contains("R")) &&
           (curentRow != 0 && curentCol != dimentions[1] - 1))
        {
            curentCol++;
            curentRow--;
        }
        //down left
        if ((curentCommand[0].Contains("D") && curentCommand[0].Contains("L")) &&
           (curentRow != 0 && curentCol != 0))
        {
            curentCol--;
            curentRow--;
        }
        result += Terminator(matrix, dimentions, curentCommand, ref curentRow, ref curentCol, moves - 1);
        return result;
    }
}

