using System;
using System.Globalization;
using System.Threading;

class MutantSquirrels
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double result = a * b * c * d;
        if (result%2==0)
        {
            Console.WriteLine("{0:f3}", result* 376439);
        }
        else
        {
            Console.WriteLine("{0:f3}",result/7);
        }
    }
}
