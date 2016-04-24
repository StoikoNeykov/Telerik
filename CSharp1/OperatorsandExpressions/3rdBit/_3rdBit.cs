using System;

    class _3rdBit
    {
        static void Main()
        {
        int num = int.Parse(Console.ReadLine()); //changed
        int mask = 1 << 3;
        int thirdBit = (num & mask) >> 3;
        Console.WriteLine(thirdBit);        
        }
    }

