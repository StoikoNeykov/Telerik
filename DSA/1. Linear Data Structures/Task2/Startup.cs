using System;
using System.Collections.Generic;

namespace Task2
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            while (stack.Count < n)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
