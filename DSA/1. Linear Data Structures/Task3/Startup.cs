using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var seq = new List<int>();

            while (input != string.Empty)
            {
                seq.Add(int.Parse(input));

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", seq.OrderBy(x => x)));
        }
    }
}
