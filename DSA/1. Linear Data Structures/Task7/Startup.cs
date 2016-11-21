using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    public class Startup
    {
        public static void Main()
        {
            var input = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var result = CountRepeatingIntegers(input);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                {
                    Console.WriteLine($"{i} -> {result[i]}");
                }
            }
        }

        public static int[] CountRepeatingIntegers(IEnumerable<int> input)
        {
            var countes = new int[input.Max() + 1];

            foreach (var item in input)
            {
                countes[item]++;
            }

            return countes;
        }
    }
}
