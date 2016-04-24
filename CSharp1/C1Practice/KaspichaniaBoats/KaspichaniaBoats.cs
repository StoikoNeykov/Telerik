using System;

class Program
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int position = 0;
        for (int i = 0; i < 2 * num; i++)         //lines
        {
            if (i - num == 2 + (num - 3) / 2)
            {
                for (int k = 0; k <= 2 * num; k++)
                {
                    if (k < i - num || k >= i)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
                break;
            }
            else
            {

                for (int j = 0; j <= 2 * num; j++)     //symbols in line
                {
                    if (j == num || i == num || i == num - j || i + num == j ||
                        i - num == j || i - num == 2 * num - j)

                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                position++;
                Console.WriteLine();
            }
        }
    }
}

