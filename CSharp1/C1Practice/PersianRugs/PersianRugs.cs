using System;

class PersianRugs
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        for (int row = 0; row < 2 * num + 1; row++)
        {
            for (int col = 0; col < 2 * num + 1; col++)
            {
                if (col == num && row == num)
                {
                    Console.Write("X");
                }
                else if (row == col || (row < num && col < num && row + distance + 1 == col) ||
                    (row > num && col > num && row - distance - 1 == col))
                {
                    Console.Write("\\");
                }
                else if ((row + col == 2 * num) || (row > num && col < num && row + col - distance - 1 == 2 * num) ||
                    (row < num && col > num && row + col + distance + 1 == 2 * num))
                {
                    Console.Write("/");
                }
                else if ((row < num - distance - 1) && (row + distance + 1 < col) && (row + col + distance + 1 < 2 * num) ||
                    (row > num + distance + 1) && (2 * num - row + distance + 1 < col) && (col + distance + 1 < row))
                {
                    Console.Write(".");
                }
                else if ((row > col && col < num && row < num) || row == num || (row < num && col > num && row + col > 2 * num) ||
                    (row > num && col < num && row + col < 2 * num) || (row > num && col > num && col > row))
                {
                    Console.Write("#");
                }
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}

