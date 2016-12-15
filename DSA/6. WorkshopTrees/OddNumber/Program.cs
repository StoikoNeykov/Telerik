using System;
using System.Collections.Generic;

namespace OddNumber
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            long result = 0;

            for (int i = 0; i < n; i++)
            {
                var number = long.Parse(Console.ReadLine());

                result ^= number;
            }

            Console.WriteLine(result);
        }
    }
}
