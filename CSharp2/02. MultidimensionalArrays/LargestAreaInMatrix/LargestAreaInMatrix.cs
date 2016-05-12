using System;
using System.Linq;

class LargestAreaInMatrix
{
    static void Main()
    {
        string text = Console.ReadLine();
        var result = text
            .Split(' ')
            .Select(z => Convert.ToInt16(z))
            .ToArray();
        short lines = result[0];
        short members = result[1];
        var matrix = new short?[lines][];
        for (short i = 0; i < lines; i++)
        {
            matrix[i] = new short?[members];
        }
        for (short i = 0; i < lines; i++)
        {
            text = null;
            text = Console.ReadLine();
            result = text
            .Split(' ')
            .Select(z => Convert.ToInt16(z))
            .ToArray();
            text = null;
            for (short j = 0; j < members; j++)
            {
                matrix[i][j] = result[j];
            }
        }
        short max = 1;
        short counter = 0;
        short? curent;
        for (short i = 0; i < lines; i++)
        {
            for (short j = 0; j < members; j++)
            {
                counter = 0;
                if (matrix[i][j] == null) //number is part of checked sequence
                {
                    continue;
                }
                else
                {
                    //unckeched number
                    counter = 1;
                    curent = matrix[i][j];
                    matrix[i][j] = null;
                    //with null mark all numbers in curent sequence
                    counter = Finder(matrix, i, j, ref curent, ref counter);
                    if (counter > max)
                    {
                        max = counter;
                    }
                }

            }
        }
        Console.WriteLine(max);
    }

    static short Finder(short?[][] matrix, short row, short col, ref short? curent, ref short counter)
    {
        if (col > 0 && matrix[row][col - 1] == curent) //left
        {
            counter++;
            matrix[row][col - 1] = null;
            counter = Finder(matrix, row, (short)(col - 1), ref curent, ref counter);
        }
        if (row < matrix.Length - 1 && matrix[row + 1][col] == curent) //down
        {
            counter++;
            matrix[row + 1][col] = null;
            counter = Finder(matrix, (short)(row + 1), col, ref curent, ref counter);
        }
        if (col < matrix[row].Length - 1 && matrix[row][col + 1] == curent) //right
        {
            counter++;
            matrix[row][col + 1] = null;
            counter = Finder(matrix, row, (short)(col + 1), ref curent, ref counter);
        }
        if (row > 0 && matrix[row - 1][col] == curent) //up
        {
            counter++;
            matrix[row - 1][col] = null;
            counter = Finder(matrix, (short)(row - 1), col, ref curent, ref counter);
        }
        return counter;
    }
}