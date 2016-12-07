using System;
using System.Linq;
using System.Numerics;

namespace Doge
{
    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var splitted = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var rows = splitted[0];
            var cols = splitted[1];
            var k = splitted[2];

            var matrix = new BigInteger[rows, cols, k + 1];
            var enemies = new bool[rows, cols];

            input = Console.ReadLine();

            var es = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in es)
            {
                var enemy = item.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                enemies[enemy[0], enemy[1]] = true;
            }

            BigInteger counter = 0;
            matrix[0, 0, 0] = 1;

            for (int d = 0; d <= k; d++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (enemies[i, j])
                        {
                            continue;
                        }

                        if (i < rows - 1 && !enemies[i + 1, j] && d > 0)
                        {
                            matrix[i, j, d] += matrix[i + 1, j, d - 1];
                        }

                        if (j < cols - 1 && !enemies[i, j + 1] && d > 0)
                        {
                            matrix[i, j, d] += matrix[i, j + 1, d - 1];
                        }

                        if (i > 0)
                        {
                            matrix[i, j, d] += matrix[i - 1, j, d];
                        }

                        if (j > 0)
                        {
                            matrix[i, j, d] += matrix[i, j - 1, d];
                        }
                    }
                }
            }

            for (long i = 0; i <= k; i++)
            {
                counter += matrix[rows - 1, cols - 1, i];
            }

            Console.WriteLine(counter);
        }
    }
}
