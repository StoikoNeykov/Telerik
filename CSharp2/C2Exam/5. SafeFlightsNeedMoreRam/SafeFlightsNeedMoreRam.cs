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
            var matrix = new List<short>[islands];
            var banned = new List<short>[islands];
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

                if (matrix[firstIsland] == null)
                {
                    matrix[firstIsland] = new List<short>();
                    banned[firstIsland] = new List<short>();
                }
                if (matrix[secondIsland] == null)
                {
                    matrix[secondIsland] = new List<short>();
                    banned[secondIsland] = new List<short>();
                }

                if (banned[firstIsland] != null && banned[firstIsland].Contains(secondIsland))
                {

                }
                else if (matrix[firstIsland].Contains(secondIsland))
                {
                    matrix[firstIsland].Remove(secondIsland);
                    matrix[secondIsland].Remove(firstIsland);

                    banned[firstIsland].Add(secondIsland);
                    banned[secondIsland].Add(firstIsland);
                }
                else
                {
                    matrix[firstIsland].Add(secondIsland);
                    matrix[secondIsland].Add(firstIsland);
                }
                curentLine = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse)
                .ToArray();
            }

            for (short i = 0; i < islands; i++)
            {
                if (matrix[i] != null && matrix[i].Count > 0)
                {
                    needToCheck[i] = true;
                }
            }

            long totalSaveRoutes = 0;
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
                        foreach (var node in matrix[curentNode])
                        {
                            if (needToCheck[node]==true)
                            {
                                que.Enqueue(node);
                                needToCheck[node] = false;
                            }
                        }
                    }

                    totalSaveRoutes += (connectedCount * (connectedCount - 1)) / 2;
                }
            }

            Console.WriteLine(totalSaveRoutes);
        }
    }
}
