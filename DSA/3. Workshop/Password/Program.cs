using System;
using System.Collections.Generic;

namespace Password
{
    public class Program
    {
        private static int counter = 0;
        private static bool itsOver = false;

        public static void Main()
        {
            var numberOfDigits = int.Parse(Console.ReadLine());
            var paternInput = Console.ReadLine().ToCharArray();
            var k = int.Parse(Console.ReadLine());

            Rec2(numberOfDigits, k, paternInput, new Stack<int>(numberOfDigits));

            //Rec2(7, 23, "<=>>=<".ToCharArray(), new Stack<int>(7));
            Console.WriteLine();
        }

        public static void Rec2(int numberOfDigits, int combinationNumber, char[] patern, Stack<int> stack)
        {
            if (itsOver)
            {
                return;
            }
            if (stack.Count == numberOfDigits)
            {
                counter++;
                if (counter == combinationNumber)
                {
                    var temp = stack.ToArray();

                    for (int i = temp.Length - 1; i >= 0; i--)
                    {
                        Console.Write(temp[i]);
                    }


                    //var temp = stack.ToList();
                    //temp.Reverse();

                    //Console.WriteLine(string.Join("", temp));
                    itsOver = true;
                }

                return;
            }

            if (stack.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    stack.Push(i);
                    Rec2(numberOfDigits, combinationNumber, patern, stack);
                    stack.Pop();
                }
            }
            else
            {
                var last = stack.Peek();
                var indexOfLast = last == 0 ? 9 : last - 1;
                var move = patern[stack.Count - 1];

                if (move == '=')
                {
                    stack.Push(last);
                    Rec2(numberOfDigits, combinationNumber, patern, stack);
                    stack.Pop();
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var indexOfCurrent = i == 0 ? 9 : i - 1;

                        if ((move == '<' && indexOfLast <= indexOfCurrent) ||
                            (move == '>' && indexOfLast >= indexOfCurrent))
                        {
                            continue;
                        }
                        else
                        {
                            stack.Push(i);
                            Rec2(numberOfDigits, combinationNumber, patern, stack);
                            stack.Pop();
                        }
                    }
                }
            }
        }
    }
}