using System;
using System.Linq;

class MegaChecker
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
        int max = 1;
        int counter = 0;
        string curent;
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < members; j++)
            {
                counter = 0;
                if (matrix[i][j] == "x") //number is part of checked sequence
                {
                    continue;
                }
                else
                {
                    //unckeched number
                    counter = 1;
                    curent = matrix[i][j];
                    matrix[i][j] = "x";
                    //with x mark all numbers in curent sequence
                    counter=Finder(matrix, i, j, curent, counter);
                    if (counter>max)
                    {
                        max = counter;
                    }
                }

            }
        }
        Console.WriteLine(max);
    }

    static int Finder(string[][] matrix, int row, int col, string curent, int counter)
    {
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                //out of range check;
                if (i < 0 || j < 0 || i > matrix.Length - 1 || j > matrix[row].Length - 1)
                {
                    continue;
                }
                else
                {
                    if (matrix[i][j]==curent)
                    {
                        counter++;
                        matrix[i][j] = "x";
                        counter=Finder(matrix, i, j, curent, counter);
                    }
                }
            }
        }
        return counter;
    }
}

