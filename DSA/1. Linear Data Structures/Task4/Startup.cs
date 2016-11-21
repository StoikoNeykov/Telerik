using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class Startup
    {
        public static void Main()
        {
            var input = new int[] { 1, 1, 4, 2, 4, 6, 3, 1 };

            var result = ExtractLongestSequenceOfEqualNumbers(input);

            Console.WriteLine(string.Join(", ", result));
        }

        public static IEnumerable<int> ExtractLongestSequenceOfEqualNumbers(IEnumerable<int> input)
        {
            var counters = new int[input.Max() + 1];

            foreach (var item in input)
            {
                counters[item]++;
            }

            var length = counters.Max();
            var element = Array.IndexOf(counters, length);

            var result = new List<int>();

            for (int i = 0; i < length; i++)
            {
                result.Add(element);
            }

            return result;
        }
    }
}
