using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    class Program
    {
        public static int max = int.MinValue;
        public static int farAway = 0;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var data = new List<KeyValuePair<int, int>>[n];

            for (int i = 0; i < n - 1; i++)
            {
                var input = Console.ReadLine();
                var splitted = input
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

                if (data[splitted[0]] == null)
                {
                    data[splitted[0]] = new List<KeyValuePair<int, int>>();
                }

                if (data[splitted[1]] == null)
                {
                    data[splitted[1]] = new List<KeyValuePair<int, int>>();
                }

                data[splitted[0]].Add(new KeyValuePair<int, int>(splitted[1], splitted[2]));
                data[splitted[1]].Add(new KeyValuePair<int, int>(splitted[0], splitted[2]));
            }


            Rec(data, new bool[n], 0, 0);
            Rec(data, new bool[n], farAway, 0);

            Console.WriteLine(max);
        }

        public static void Rec(List<KeyValuePair<int, int>>[] data, bool[] visited, int current, int sum)
        {
            visited[current] = true;

            foreach (var item in data[current])
            {
                if (visited[item.Key])
                {
                    continue;
                }

                sum += item.Value;
                Rec(data, visited, item.Key, sum);
                if (sum > max)
                {
                    max = sum;
                    farAway = item.Key;
                }
                sum -= item.Value;
            }

            visited[current] = false;
        }
    }
}