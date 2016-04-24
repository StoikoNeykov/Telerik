using System;
using System.Numerics;
class _248
{
    static void Main()
    {
        Int64 a = Int64.Parse(Console.ReadLine());
        Int64 b = Int64.Parse(Console.ReadLine());
        Int64 c = Int64.Parse(Console.ReadLine());
        BigInteger r;
        if (b == 2)
        {
            r = a % c;
        }
        else if (b == 4)
        {
            r = a + c;
        }
        else
        {
            r = a * c;
        }
        Console.WriteLine("{0}", r % 4 == 0 ? r / 4 : r % 4);
        Console.WriteLine(r);
    }
}
