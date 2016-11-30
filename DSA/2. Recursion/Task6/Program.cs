using System;

namespace Task6
{
    public class Program
    {
        public static void Main()
        {
            var set = new string[] { "hi", "a", "b", "c", "bye" };
            var k = 3;

            GenerateVariationsWithRepetition(k, 0, -1, set, new string[k]);
        }

        public static void GenerateVariationsWithRepetition(int k, int index, int indexOfLast, string[] set, string[] actual)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" -> ", actual));
                return;
            }

            for (int i = indexOfLast + 1; i < set.Length; i++)
            {
                actual[index] = set[i];
                GenerateVariationsWithRepetition(k, index + 1, i, set, actual);
            }
        }
    }
}
