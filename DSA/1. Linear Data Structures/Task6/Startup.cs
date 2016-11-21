using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    public class Startup
    {
        public static void Main()
        {
            var input = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var result = ExtractNumbersThatoccourEvenTimes(input);

            Console.WriteLine(string.Join(", ", result));
        }

        public static IEnumerable<int> ExtractNumbersThatoccourEvenTimes(IEnumerable<int> input)
        {
            var countes = new int[input.Max() + 1];

            foreach (var item in input)
            {
                countes[item]++;
            }

            var result = new List<int>();

            foreach (var item in input)
            {
                if (countes[item] % 2 == 0)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
