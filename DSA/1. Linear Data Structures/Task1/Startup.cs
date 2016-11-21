using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Startup
    {
        public static void Main()
        {
            var seq = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                {
                    break;
                }

                var num = int.Parse(input);

                if (num > 0)
                {
                    seq.Add(num);
                }
            }

            var sum = seq.Sum();

            Console.WriteLine(sum);
            Console.WriteLine((double)sum / seq.Count);
        }
    }
}
