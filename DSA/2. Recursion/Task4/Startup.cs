using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class Startup
    {
        public static void Main()
        {
            var number = 4;

            GeneratePermutations(number, new Stack<int>());
        }

        public static void GeneratePermutations(int max, Stack<int> stack)
        {
            if (stack.Count < max)
            {
                for (int i = 1; i <= max; i++)
                {
                    if (!stack.Contains(i))
                    {
                        stack.Push(i);
                        GeneratePermutations(max, stack);
                        stack.Pop();
                    }
                }
            }
            else
            {
                var list = stack.ToList();
                list.Reverse();
                Console.WriteLine(string.Join(", ", list));
            }
        }
    }
}