using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char symbol = Convert.ToChar(Console.ReadLine());
        var matrix = new int[size, size];
        switch (symbol)
        {
            case 'a': TheACase(matrix, size); break;
            case 'b': TheBCase(matrix, size); break;
            case 'c': TheCCase(matrix, size); break;
            case 'd': TheDCase(matrix, size); break;
            default: Console.WriteLine("Srsly?"); break;
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j]);
                if (j != size - 1)
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }

    static void TheACase(int[,] matrix, int size)
    {
        int counter = 1;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[j, i] = counter;
                counter++;
            }
        }
    }
    static void TheBCase(int[,] matrix, int size)
    {
        int counter = 1;
        for (int i = 0; i < size; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[j, i] = counter;
                    counter++;
                }
            }
            else
            {
                for (int j = size - 1; j >= 0; j--)
                {
                    matrix[j, i] = counter;
                    counter++;
                }
            }
        }
    }
    static void TheCCase(int[,] matrix, int size)
    {
        int count = 1;
        var qMatrix = new Stack<int>[size];
        for (int i = 0; i < size; i++)
        {
            qMatrix[i] = new Stack<int>();
        }
        for (int maxCount = 0; count <= size * size; maxCount++)
        {
            for (int i = 0; i < size; i++)
            {
                if (qMatrix[i].Count == size || i > maxCount) //when to skip
                {
                    continue;
                }
                else
                {
                    qMatrix[i].Push(count);
                    count++;
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[j, i] = qMatrix[i].Pop();
            }
        }

    }
    static void TheDCase(int[,] matrix, int size)
    {
        int direction = 0; // %4 ??? 0-right 1-down 2-left 3-up
        int curent = 1;
        int col = 0;                    //mess up with col and row and in the end only changed indexes
        int row = 0;                    //to output that i need 
        do
        {
            matrix[col, row] = curent;
            switch (direction % 4)
            {
                case 0:                //right
                    if ((col == size - 1) || (matrix[col + 1, row] != 0))     //if end of line or not empty
                    {
                        row++;
                        direction++;
                    }
                    else col++;
                    break;
                case 1:                 //down
                    if ((row == size - 1) || (matrix[col, row + 1] != 0))     //if hit bottom or not empty
                    {
                        col--;
                        direction++;
                    }
                    else row++;
                    break;
                case 2:                 //left
                    if ((col == 0) || (matrix[col - 1, row] != 0))       //if end of line or not empty
                    {
                        row--;
                        direction++;
                    }
                    else col--;
                    break;
                case 3:                 //up
                    if (matrix[col, row - 1] != 0) //is empty check
                    {
                        col++;
                        direction++;
                    }
                    else row--;
                    break;
            }

            curent++;
        } while (curent <= size * size);
    }
}

