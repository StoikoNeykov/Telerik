using System;
using System.Collections.Generic;
using System.Linq;

namespace FindNumber
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var splitted = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList(); ;
            var n = splitted[0];
            var k = splitted[1];

            input = Console.ReadLine();

            var arr = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var collection = new SortedDictionary<char, List<string>>();

            foreach (var item in arr)
            {
                char key = item[0];

                if (collection.ContainsKey(key))
                {
                    collection[key].Add(item);
                }
                else
                {
                    collection[key] = new List<string>();
                    collection[key].Add(item);
                }
            }

            int oldCount = 0;
            int currentCount = 0;
            char neededKey = '0';

            for (int i = 0; i < 256; i++)
            {
                if (collection.ContainsKey((char)i))
                {
                    oldCount = currentCount;
                    currentCount += collection[(char)i].Count;

                    if (currentCount > k)
                    {
                        neededKey = (char)i;
                        break;
                    }
                }
            }

            var first = collection[neededKey].OrderBy(x => x).Skip(k - oldCount).First();

            Console.WriteLine(first);
        }
    }
}