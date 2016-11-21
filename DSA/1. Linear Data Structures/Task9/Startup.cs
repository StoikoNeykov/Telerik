using System;
using System.Collections.Generic;

namespace Task9
{
    public class Startup
    {
        public static void Main()
        {
            var que = new Queue<int>();

            var n = 2; // int.Parse(Console.ReadLine());

            que.Enqueue(n);

            int dequeCount = 0;
            int current = 0;

            while (true)
            {
                if (dequeCount + que.Count > 50)
                {
                    // Generated Enough
                    break;
                }

                current = que.Dequeue();
                dequeCount++;

                que.Enqueue(current + 1);
                que.Enqueue(2 * current + 1);
                que.Enqueue(current + 2);
            }

            while (dequeCount < 50)
            {
                current = que.Dequeue();
                dequeCount++;
            }

            Console.WriteLine(current);
        }
    }
}
