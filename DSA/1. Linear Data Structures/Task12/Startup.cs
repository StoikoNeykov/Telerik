using System;
using System.Collections.Generic;

namespace Task12
{
    public class Startup
    {
        public static void Main()
        {
            var stack = new CustomStack<int>();

            stack.Push(15);
            stack.Push(14);
            stack.Push(13);
            stack.Push(12);
            stack.Push(11);
            stack.Push(10);
            var value = stack.Pop();
            stack.Push(value);
            stack.Push(9);
            stack.Push(8);
            stack.Push(7);
            stack.Push(6);
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            // without 1

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Count: {stack.Count}");

            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Count: {stack.Count}");

            foreach (var item in stack)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine($"Count: {stack.Count}");
        }
    }
}
