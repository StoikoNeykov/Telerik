using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var splittedInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<int>();

            foreach (var str in splittedInput)
            {
                int item;

                if (int.TryParse(str, out item))
                {
                    stack.Push(item);
                }
                else
                {
                    ExecuteOperator(str, stack);
                }
            }

            Console.WriteLine(stack.Pop());
        }

        private static void ExecuteOperator(string str, Stack<int> stack)
        {
            int second = stack.Pop();
            int first = stack.Pop();

            switch (str)
            {
                case "+":
                    stack.Push(first + second);
                    break;
                case "-":
                    stack.Push(first - second);
                    break;
                case "*":
                    stack.Push(first * second);
                    break;
                case "/":
                    stack.Push(first / second);
                    break;
                case "&":
                    stack.Push(first & second);
                    break;
                case "|":
                    stack.Push(first | second);
                    break;
                case "^":
                    stack.Push(first ^ second);
                    break;

                default:
                    throw new StackOverflowException("Just becouse why not!");
            }
        }
    }
}
