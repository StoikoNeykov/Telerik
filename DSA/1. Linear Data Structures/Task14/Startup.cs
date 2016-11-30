using System;
using System.Collections.Generic;

namespace Task14
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new string[6, 6]
                {
                    {"0","0","0","x","0","x" },
                    {"0","x","0","x","0","x" },
                    {"0","*","x","0","x","0" },
                    {"0","x","0","0","0","0" },
                    {"0","0","0","x","x","0" },
                    {"0","0","0","x","0","x" }
                };

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            int startX = -1;
            int startY = -1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == "*")
                    {
                        startX = i;
                        startY = j;
                        break;
                    }
                }
            }

            var dx = new int[] { 0, 1, 0, -1 };
            var dy = new int[] { -1, 0, 1, 0 };

            var que = new Queue<int>();

            que.Enqueue(startX);
            que.Enqueue(startY);

            while (que.Count > 0)
            {
                var currentX = que.Dequeue();
                var currentY = que.Dequeue();


                for (int i = 0; i < dx.Length; i++)
                {
                    var checkX = currentX + dx[i];
                    var checkY = currentY + dy[i];

                    bool isOutOfArrayRange = (checkX < 0) ||
                                                (checkX >= rows ||
                                                (checkY < 0) ||
                                                (checkY >= cols));

                    if (isOutOfArrayRange)
                    {
                        continue;
                    }

                    bool isOcupated = matrix[checkX, checkY] != "0";

                    if (isOcupated)
                    {
                        continue;
                    }
                    var next = 0;

                    if (matrix[currentX, currentY] == "*")
                    {
                        next = 1;
                    }
                    else
                    {
                        next = int.Parse(matrix[currentX, currentY]) + 1;
                    }

                    matrix[checkX, checkY] = next.ToString();

                    que.Enqueue(checkX);
                    que.Enqueue(checkY);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
