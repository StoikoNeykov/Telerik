using System;

class Cube
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        for (int row = 0; row < 2 * num - 1; row++)
        {
            for (int col = 0; col < 2 * num - 1; col++)
            {
                if (
                    (row + col < num - 1) ||            //top left
                    (row + col > 3 * num - 3) ||        //bottom right
                    (row >= num && row < 2 * num - 2 && col > 0 && col < num - 1)   //inside cube
                    )
                {
                    Console.Write(" ");
                }
                else if (row < num - 1 && row > 0 && row + col >= num && row + col < 2 * num - 2)
                {
                    Console.Write("/");
                }
                else if (col > num - 1 && col < 2 * num - 2 && row + col > 2 * num - 2 && row + col < 3 * num - 3)
                {
                    Console.Write("X");
                }
                else
                    Console.Write(":");
            }

            Console.WriteLine();
        }
    }
}

