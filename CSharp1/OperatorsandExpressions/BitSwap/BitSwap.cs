using System;

    class BitSwap
    {
        static void Main()
        {
        long num = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine()); 
        long mask,pBit, qBit; 
        for (int i = 0; i < k; i++)
        {
            mask = 1L << p+i;
            pBit = (num & mask) >> p+i;       
            mask = 1L << q+i;
            qBit = (num & mask) >> q+i;
            if (pBit!=qBit)
            {
                mask = (1L << p+i) | (1L << q+i);
                num = num ^ mask;
            }
        }
        Console.WriteLine(num);
    }
    }

