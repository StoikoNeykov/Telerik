using System;

    class BitExchange
    {
        static void Main()
        {
        long num = long.Parse(Console.ReadLine());
        long mask1 = 56L;
        long mask2 = 117440512L;
        long result1 = num & mask1;
        long result2 = num & mask2;
        num = num & ~117440568;
        num = num | (result1 << 21) | (result2 >> 21);
        Console.WriteLine(num);
        }
    }

