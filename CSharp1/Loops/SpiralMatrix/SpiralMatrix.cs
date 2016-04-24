using System;

class SpiralMatrix
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int[,] matrix = new int[num, num];
        int direction = 0; // %4 ??? 0-right 1-down 2-left 3-up
        int curent = 1;
        int row = 0;                    //mess up with col and row and in the end only changed indexes
        int col = 0;                    //to output that i need 
        do
        {

            matrix[row, col] = curent;

            switch (direction % 4)
            {
                case 0:                //right
                    if ((row == num - 1) || (matrix[row + 1, col] != 0))     //if end of line or not empty
                    {
                        col++;
                        direction++;
                    }
                    else row++;
                    break;
                case 1:                 //down
                    if ((col == num - 1) || (matrix[row, col + 1] != 0))     //if hit bottom or not empty
                    {
                        row--;
                        direction++;
                    }
                    else col++;
                    break;
                case 2:                 //left
                    if ((row == 0) || (matrix[row - 1, col] != 0))       //if end of line or not empty
                    {
                        col--;
                        direction++;
                    }
                    else row--;
                    break;
                case 3:                 //up
                    if (matrix[row, col - 1] != 0) //is empty check
                    {
                        row++;
                        direction++;
                    }
                    else col--;
                    break;
            }

            curent++;
        } while (curent <= num * num);
        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < num; j++)
            {
                Console.Write("{0}", matrix[j, i]);
                if (j != num - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

