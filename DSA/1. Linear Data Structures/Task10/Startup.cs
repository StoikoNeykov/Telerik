using System;
using System.Collections.Generic;

namespace Task10
{
    public class Startup
    {
        public static void Main()
        {
            var n = 5;
            var m = 16;

            var result = FindShortestSequenceOfOperation(n, m);

            Console.WriteLine(string.Join(" -> ", result));
        }

        public static IEnumerable<int> FindShortestSequenceOfOperation(int start, int end)
        {
            var result = new List<int>();

            int next = start;
            result.Add(start);

            while (true)
            {
                var current = next;

                var isPosibleToHitTheEnd = (current + 1 == end) || (current + 2 == end) || (current * 2 == end);

                if (isPosibleToHitTheEnd)
                {
                    result.Add(end);
                    return result;
                }

                if (current * 2 * 2 <= end)
                {
                    next = current * 2;
                }
                else if ((current + 2) * 2 <= end)
                {
                    next = current + 2;
                }
                else if ((current + 1) * 2 <= end)
                {
                    next = current + 1;
                }
                else if (current * 2 + 2 <= end)
                {
                    next = current * 2;
                }
                else if (current * 2 + 1 <= end)
                {
                    next = current * 2;
                }
                else if (current + 2 + 2 <= end)
                {
                    next = current + 2;
                }
                else if (current + 2 + 1 == end)
                {
                    result.Add(current + 2);
                    result.Add(current + 1);

                    return result;
                }

                result.Add(next);
            }
        }
    }
}
