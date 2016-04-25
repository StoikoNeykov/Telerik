using System;
using System.Globalization;
using System.Threading;

    class Numbers1toN
    {
        static void Main()
        {
        ushort n = ushort.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
        }
    }

