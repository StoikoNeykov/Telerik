using System;

namespace Task5
{
    public class Program
    {
        public static void Main()
        {
            var set = new string[] { "hi", "a", "b", "c", "bye" };
            var k = 3;

            GenerateVariationsWithRepetition(k, 0, set, new string[k]);
        }

        public static void GenerateVariationsWithRepetition(int k, int index, string[] set, string[] actual)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" -> ", actual));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                actual[index] = set[i];
                GenerateVariationsWithRepetition(k, index + 1, set, actual);
            }
        }
    }
}
