using System;

class PeaceOfCake
{
    static void Main()
    {
        ulong a = ulong.Parse(Console.ReadLine());
        ulong b = ulong.Parse(Console.ReadLine());
        ulong c = ulong.Parse(Console.ReadLine());
        ulong d = ulong.Parse(Console.ReadLine());
        if ((a * d + b * c) / (b * d) >= 1)
        {
            Console.WriteLine((a * d + b * c) / (b * d));
        }
        else
        {
            decimal result = (decimal)(a * d + b * c) /(decimal)(b * d);
            Console.WriteLine("{0:f22}", Math.Round(result, 22));
        }
        Console.WriteLine("{0}/{1}", a * d + b * c, b * d);
    }
}

