using System;
using System.Collections.Generic;

namespace Task5
{
    public class Startup
    {
        public static void Main()
        {
            var input = new int[] { 4, 3, -6, 3, -8, 3, 0 - 100 };

            var result = ExtractNotNegative(input);

            Console.WriteLine(string.Join(", ", result));
        }

        public static IEnumerable<int> ExtractNotNegative(IEnumerable<int> input)
        {
            var result = new List<int>();

            foreach (var item in input)
            {
                if (item >= 0)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
