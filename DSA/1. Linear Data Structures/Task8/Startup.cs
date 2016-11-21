using System;
using System.Collections.Generic;
using System.Linq;

namespace Task8
{
    public class Startup
    {
        public static void Main()
        {
            var input = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var result = FindMajorantIfExsist(input);

            Console.WriteLine(result);
        }

        public static string FindMajorantIfExsist(IEnumerable<int> input)
        {
            var counters = new int[input.Max() + 1];

            foreach (var item in input)
            {
                counters[item]++;
            }

            var max = counters.Max();

            if (max >= input.Count() / 2 + 1)
            {
                return Array.IndexOf(counters, max).ToString();
            }
            else
            {
                return "There is no majorant!";
            }
        }
    }
}
