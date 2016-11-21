using System;

namespace Task11
{
    public class Startup
    {
        public static void Main()
        {
            var list = new CustomLinkedList<int>();

            list.Add(5);
            list.Add(0);
            list.Add(2);
            var node = list.AddLast(8);
            list.Add(5);
            list.AddBefore(node, 7);
            list.Add(5);

            Console.WriteLine($"Count is: {list.Count}");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
