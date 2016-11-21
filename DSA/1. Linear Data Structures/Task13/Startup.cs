using System;

namespace Task13
{
    public class Startup
    {
        public static void Main()
        {
            var queue = new CustomQueue<int>();

            for (int i = 0; i < 15; i++)
            {
                queue.Enqueue(i);

                if (i == 5 || i == 10)
                {
                    Console.WriteLine(queue.Dequeue());
                }
            }

            Console.WriteLine($"Count: {queue.Count}");

            Console.WriteLine($"Contains 8? {queue.Contains(8)}");
            Console.WriteLine($"Contains 1? {queue.Contains(1)}");

            Console.WriteLine($"Peek: {queue.Peek()}");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine($"Count: {queue.Count}");

        }
    }
}
