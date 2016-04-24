using System;

    class NthBit
    {
        static void Main()
        {
        long num = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long mask = 1 << n;
        long theBit = (num & mask) >> n;
        Console.WriteLine(theBit);
        }
    }



