namespace C2Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Safe_flights
    {
        public static void Main()
        {

            short islands = short.Parse(Console.ReadLine());

            // graph holder
            var matrix = new byte[islands, islands];

            // islands with at least 1 save path 
            var needToCheck = new bool[islands];

            // input
            var curentLine = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse)
                .ToArray();

            while (curentLine[0] != -1 && curentLine[1] != -1)
            {
                var firstIsland = curentLine[0];
                var secondIsland = curentLine[1];
                if (firstIsland >= 0 && firstIsland < islands && secondIsland >= 0 && secondIsland < islands)
                {
                    matrix[firstIsland, secondIsland]++;
                    matrix[secondIsland, firstIsland]++;
                }

                curentLine = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse)
                .ToArray();
            }

            for (short i = 0; i < islands; i++)
            {
                for (short j = i; j < islands; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        needToCheck[i] = true;
                        needToCheck[j] = true;
                    }
                }
            }

            long totalSafeRoutes = 0;
            for (short i = 0; i < islands; i++)
            {
                if (needToCheck[i] == true)
                {
                    // BFS
                    short connectedCount = 0;
                    var que = new Queue<short>();
                    que.Enqueue(i);
                    needToCheck[i] = false;
                    while (que.Count > 0)
                    {
                        short curentNode = que.Dequeue();
                        connectedCount++;
                        for (short j = 0; j < islands; j++)
                        {
                            if (matrix[curentNode, j] == 1 && needToCheck[j] == true)
                            {
                                que.Enqueue(j);
                                needToCheck[j] = false;
                            }
                        }
                    }

                    totalSafeRoutes += (connectedCount * (connectedCount - 1)) / 2;
                }
            }

            Console.WriteLine(totalSafeRoutes);
        }
    }
}
